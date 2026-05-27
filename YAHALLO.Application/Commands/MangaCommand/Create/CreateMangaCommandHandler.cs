using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Events;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Kafka;
using YAHALLO.Infrastructure.Redis;

namespace YAHALLO.Application.Commands.MangaCommand.Create
{
    public class CreateMangaCommandHandler : IRequestHandler<CreateMangaCommand, string>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMangaSeasonRepository _mangaSeasonRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IFiles<IFormFile> _files;
        private readonly IImageRepository _imageRepository;
        private readonly IRedisCacheService _cache;
        private readonly IKafkaProducer _kafkaProducer;
        private readonly ILogger _logger;
        public CreateMangaCommandHandler(
            IMangaRepository mangaRepository,
            IMangaSeasonRepository mangaSeasonRepository,
            ICurrentUserService currentUser,
            IFiles<IFormFile> files,
            IImageRepository imageRepository,
            IRedisCacheService cache,
            IKafkaProducer kafkaProducer,
            ILoggerExtension logger)
        {
            _mangaRepository = mangaRepository;
            _mangaSeasonRepository = mangaSeasonRepository;
            _currentUser = currentUser;
            _files = files;
            _imageRepository = imageRepository;
            _cache = cache;
            _kafkaProducer = kafkaProducer;
            _logger = logger.CreateLogger("Logs/Mangas", "Create_manga");
        }
        public async Task<string> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
        {
            var query = _mangaRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            foreach (var property in typeof(CreateMangaCommand).GetProperties())
            {
                if (property.PropertyType == typeof(IFormFile)) continue;
                var propertyValue = property.GetValue(request);
                if (propertyValue != null)
                {
                    var expression = _mangaRepository.IExpressionEqual(property, propertyValue);
                    if(expression !=null) query = query.Where(expression);
                }
            }
            var checkMangaExist = await _mangaRepository
                .FindAsync(query, cancellationToken);
            if(checkMangaExist != null)
            {
                _logger.Error($"Manga had exist");
                throw new DuplicateException("Đã tồn tại manga với các thông tin trên");
            }
            var newManga = new MangaEntity
            {
                Name = request.Name,
                Description = request.Description ?? "",
                Level = request.Level,
                Status = request.Status,
                Type = request.Type,
                Countries = request.Countries,
                Season = request.Season,
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUser.UserId,
                UserId = _currentUser.UserId
            };
            _mangaRepository.Add(newManga);
            var result = await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                _files.CreateFolder($"Data\\Manga", newManga.Id);
                var checkMangaSeasonExist = await _mangaSeasonRepository
                    .FindAsync(x => x.Id == request.MangaSeasonId, cancellationToken);
                if(checkMangaSeasonExist == null)
                {
                    var newMangaSeason = new MangaSeasonEntity(season: 1,description: null);
                    newMangaSeason.MangaEntities.Add(newManga);
                    _mangaSeasonRepository.Add(newMangaSeason);
                    var retuls = await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result <= 0)
                    {
                        _logger.Error($"Error when create manga");
                        throw new Exception("đã xảy ra lỗi");
                    }
                }
                else
                {
                    checkMangaSeasonExist.MangaEntities.Add(newManga);
                    _mangaSeasonRepository.Update(checkMangaSeasonExist);
                    var retuls = await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result <= 0)
                    {
                        _logger.Error($"Error when create manga");
                        throw new Exception("đã xảy ra lỗi");
                    }
                }
                var path= $"Data\\Thumbnail";
                if(request.Thumbnail != null)
                {
                    var mangaThumbnail = new ImageEntity(index: 1, $"{path}\\{request.Thumbnail.FileName}",null, TypeImage.Manga, null, null, newManga.Id, _currentUser.UserId, DateTime.Now);
                    _imageRepository.Add(mangaThumbnail);
                    var resultimg = await _imageRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (resultimg > 0)
                    {
                        var upfiles = await _files.UpLoadimage(request.Thumbnail, path);
                        if (upfiles == true)
                        {
                            await PublishMangaChangedAsync(newManga.Id, "Created", cancellationToken);
                            _logger.Information($"Create success manga with Id: {newManga.Id} - Name: {newManga.Name}");
                            return "Thêm thành công";
                        }
                    }
                    throw new NotFoundException("Đã gặp lỗi trong quá trình cập nhật dữ liệu");
                }
                await PublishMangaChangedAsync(newManga.Id, "Created", cancellationToken);
                _logger.Information($"Create success manga with Id: {newManga.Id} - Name: {newManga.Name}");
                return "Thêm thành công";
            }
            else
            {
                _logger.Error($"Create failed manga with Id: {newManga.Id} - Name: {newManga.Name}");
                return "Đã gặp lỗi trong quá trình thêm dữ liệu";
            }
        }

        private async Task PublishMangaChangedAsync(string mangaId, string changeType, CancellationToken cancellationToken)
        {
            await _cache.RemoveByPrefixAsync(MangaCacheKeys.CatalogPrefix, cancellationToken);

            var changedEvent = new MangaChangedEvent(
                mangaId,
                changeType,
                _currentUser.UserId,
                DateTime.UtcNow);

            await _kafkaProducer.PublishAsync("yahallo.manga.changed", mangaId, changedEvent, cancellationToken);
        }
    }
}
