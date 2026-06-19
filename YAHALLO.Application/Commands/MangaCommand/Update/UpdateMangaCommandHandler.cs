using MediatR;
using Microsoft.AspNetCore.Http;
using YAHALLO.Application.Commands.MangaCommand.DTOs;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

namespace YAHALLO.Application.Commands.MangaCommand.Update
{
    public class UpdateMangaCommandHandler : IRequestHandler<UpdateMangaCommand, UpdateMangaResponseDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IStorageService<MangaThumbnail> _avatarStorage;
        private readonly IStorageService<MangaBackground> _backgroundStorage;
        public UpdateMangaCommandHandler(
            IMangaRepository mangaRepository,
            ICurrentUserService currentUser,
            IStorageService<MangaThumbnail> avatarStorage,
            IStorageService<MangaBackground> backgroundStorage)
        {
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
            _avatarStorage = avatarStorage;
            _backgroundStorage = backgroundStorage;
        }
        public async Task<UpdateMangaResponseDto> Handle(UpdateMangaCommand request, CancellationToken cancellationToken)
        {
            var manga = await _mangaRepository.FindSelectAsync(x => x
                .Where(x => x.Id == request.Id)
                .Select(m => new MangaEntity
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Level = m.Level,
                    Status = m.Status,
                    Type = m.Type,
                    Countries = m.Countries,
                    Season = m.Season,
                    UpdateDate = m.UpdateDate,
                    IdUserUpdate = m.IdUserUpdate,
                    MangaGroup = m.MangaGroup == null ? null : new MangaGroupEntity
                    {
                        Id = m.MangaGroup.Id,
                        MangaEntities = m.MangaGroup.MangaEntities.Select(x => x).ToList()
                    }
                })
                , cancellationToken);
            if (manga == null)
                throw new NotFoundException($"Không tồn tại manga với Id {request.Id}");

            // Quyền truy cập đã được kiểm soát qua [Authorize(Roles="Admin,Mod")] trên command.

            S3Response? avatarUploadUrl = null;
            if (request.Avatar != null)
            {
                avatarUploadUrl = await _avatarStorage.CreateSignedURL(new MangaThumbnail
                {
                    FileName = request.Avatar.FileName,
                    ContentType = request.Avatar.ContentType,
                    FileSize = request.Avatar.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            S3Response? backgroundUploadUrl = null;
            if (request.Background != null)
            {
                //test for upload to s3
                backgroundUploadUrl = await _backgroundStorage.CreateSignedURL(new MangaBackground
                {
                    FileName = request.Background.FileName,
                    ContentType = request.Background.ContentType,
                    FileSize = request.Background.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }

            if (manga.MangaGroup != null && manga.MangaGroup.MangaEntities.All(x => x.Season != request.Season))
                manga.Season = request.Season;

            manga.Name = request.Name ?? manga.Name;
            manga.Description = request.Description ?? manga.Description;
            manga.Level = request.Level ?? manga.Level;
            manga.Status = request.Status ?? manga.Status;
            manga.Type = request.Type ?? manga.Type;
            manga.Countries = request.Countries ?? manga.Countries;
            manga.UpdateDate = DateTime.UtcNow;
            manga.IdUserUpdate = _currentUser.UserId;
            manga.MangaThumbnail = (avatarUploadUrl != null && !string.IsNullOrEmpty(avatarUploadUrl.Url))
                ? S3UrlHelper.ToCloudFrontUrl(avatarUploadUrl.Url, avatarUploadUrl.CloundFrontDomain)
                : manga.MangaThumbnail;

            manga.MangaBackground = (backgroundUploadUrl != null && !string.IsNullOrEmpty(backgroundUploadUrl.Url))
             ? S3UrlHelper.ToCloudFrontUrl(backgroundUploadUrl.Url, backgroundUploadUrl.CloundFrontDomain)
             : manga.MangaBackground;

            var response = new UpdateMangaResponseDto
            {
                Message = "Cập nhật manga thất bại",
                AvatarUrl = avatarUploadUrl?.Url,
                BackgroundUrl = backgroundUploadUrl?.Url
            };
            _mangaRepository.Update(manga);
            var result= await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
                response.Message = "Cập nhật thành công";

            return response;
        }
    }
}
