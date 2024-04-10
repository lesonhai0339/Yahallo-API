using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using NotMappedAttribute = YAHALLO.Domain.Exceptions.NotMappedAttribute;

namespace YAHALLO.Application.Commands.ChapterCommand.Create
{
    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, ResponeResult>
    {
        private IChapterRepository _chapterRepository;
        private IMangaRepository _mangaRepository;
        private ICurrentUserService _currentUser;
        private readonly IFiles<IFormFile> _files;
        public CreateChapterCommandHandler(IChapterRepository chapterRepository, IMangaRepository mangaRepository, ICurrentUserService currentUser
            ,IFiles<IFormFile> files)
        {
            _chapterRepository = chapterRepository;
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
            _files = files;
        }

        public async Task<ResponeResult> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            var checkRole = await _currentUser.IsInRoleAsync("1");
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => x.Id == request.MangaId, cancellationToken);
            if(checkMangaExist == null || !string.IsNullOrEmpty(checkMangaExist.IdUserDelete) && checkMangaExist.DeleteDate.HasValue)
            {
                throw new NotFoundException("Không tìm thấy manga hoặc manga đã bị vô hiệu");
            }
            if(checkMangaExist.UserId != _currentUser.UserId || checkRole == false && checkMangaExist.UserId != _currentUser.UserId)
            {
                throw new NotFoundException("Tài khoản hiện tại không có quyền thực hiện chức năng này");
            }
            var checkChapterExist = await _chapterRepository
                .FindAllAsync(x => x.MangaId == request.MangaId && x.Index == request.Index
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkChapterExist.Count() != 0)
            {
                throw new DuplicateException("Đã tồn tại chapter với index cho manga tương tự");
            }
            var path = $"Data\\Manga\\{checkMangaExist.Id}";
            if (request.Images != null)
            {
                if (request.ImageUrls != null)
                {
                    if(request.Images.Count() != request.ImageUrls.Count())
                    {
                        throw new NotMappedAttribute("File ảnh và Url không khớp số lượng");
                    }
                    var chapter = new ChapterEntity
                    {
                        Title = request.Title,
                        Index = request.Index,
                        MangaId = request.MangaId,
                        IdUserCreate = _currentUser.UserId,
                        CreateDate = DateTime.Now
                    };
                    _files.CreateFolder(path, chapter.Id);
                    var listChapterImage = new List<ImageEntity>();
                    var imagesOrderby = request.Images.OrderBy(x => x.FileName).ToList();
                    var imageUrlsOrderby = request.ImageUrls.OrderBy(x => x).ToList();
                    for(int i = 0; i< (request.Images.Count() + request.ImageUrls.Count()/ 2); i++)
                    {
                        var imagePath = $"{path}\\{chapter.Id}";
                        var imageChapter = new ImageEntity
                        {
                            Index = i + 1,
                            TypeImage = TypeImage.Manga,
                            BaseUrl = imagePath,
                            CloudUrl = imageUrlsOrderby[i]
                        };
                        listChapterImage.Add(imageChapter);
                        var image = imagesOrderby[i];
                        await _files.UpLoadimage(image, imagePath);
                    }
                    chapter.ImagesEntities = listChapterImage;
                    _chapterRepository.Add(chapter);
                    var result = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if(result > 0)
                    {
                        return new ResponeResult(message: "Tạo thành công");
                    }
                    else
                    {
                        return new ResponeResult(message: "Tạo thất bại");
                    }
                }
                else
                {
                    var chapter = new ChapterEntity
                    {
                        Title = request.Title,
                        Index = request.Index,
                        MangaId = request.MangaId,
                        IdUserCreate = _currentUser.UserId,
                        CreateDate = DateTime.Now
                    };
                    _files.CreateFolder(path, chapter.Id);
                    var listChapterImage = new List<ImageEntity>();
                    var imagesOrderby = request.Images.OrderBy(x => x.FileName).ToList();
                    for (int i = 0; i < request.Images.Count(); i++)
                    {
                        var imagePath = $"{path}\\{chapter.Id}";
                        var imageChapter = new ImageEntity
                        {
                            Index = i + 1,
                            TypeImage = TypeImage.Manga,
                            BaseUrl = imagePath,
                        };
                        listChapterImage.Add(imageChapter);
                        var image = imagesOrderby[i];
                        await _files.UpLoadimage(image, imagePath);
                    }
                    chapter.ImagesEntities = listChapterImage;
                    _chapterRepository.Add(chapter);
                    var result = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result > 0)
                    {
                        return new ResponeResult(message: "Tạo thành công");
                    }
                    else
                    {
                        return new ResponeResult(message: "Tạo thất bại");
                    }
                }
            }
            if(request.ImageUrls != null)
            {
                var chapter = new ChapterEntity
                {
                    Title = request.Title,
                    Index = request.Index,
                    MangaId = request.MangaId,
                    IdUserCreate = _currentUser.UserId,
                    CreateDate = DateTime.Now
                };
                var listChapterImage = new List<ImageEntity>();
                var imageUrlsOrderby = request.ImageUrls.OrderBy(x => x).ToList();
                for (int i = 0; i < request.ImageUrls.Count(); i++)
                {
                    var imageChapter = new ImageEntity
                    {
                        Index = i + 1,
                        TypeImage = TypeImage.Manga,
                        BaseUrl = imageUrlsOrderby[i],
                        CloudUrl = imageUrlsOrderby[i]
                    };
                    listChapterImage.Add(imageChapter);
                }
                chapter.ImagesEntities = listChapterImage;
                _chapterRepository.Add(chapter);
                var result = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return new ResponeResult(message: "Tạo thành công");
                }
                else
                {
                    return new ResponeResult(message: "Tạo thất bại");
                }
            }
            return new ResponeResult(message: "Đã xảy ra lỗi");
        }
    }
}
