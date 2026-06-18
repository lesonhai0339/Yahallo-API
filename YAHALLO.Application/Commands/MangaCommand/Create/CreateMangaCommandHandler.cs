using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.DTOs;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

namespace YAHALLO.Application.Commands.MangaCommand.Create
{
    public class CreateMangaCommandHandler : IRequestHandler<CreateMangaCommand, CreateMangaResponseDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IStorageService<MangaThumbnail> _avatarStorage;
        private readonly IStorageService<MangaBackground> _backgroundStorage;   
        public CreateMangaCommandHandler(
            IMangaRepository mangaRepository,
            ICurrentUserService currentUser,
            IStorageService<MangaThumbnail> avatarStorage,
            IStorageService<MangaBackground> backgroundStorage
            )
        {
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
            _avatarStorage = avatarStorage;
            _backgroundStorage = backgroundStorage;
        }
        public async Task<CreateMangaResponseDto> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
        {
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

            var newManga = new MangaEntity
            {
                Name = request.Name,
                Description = request.Description,
                Level = request.Level,
                Status = request.Status,
                Type = request.Type,
                Countries = request.Countries,
                Season = request.Season,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = _currentUser.UserId,
                UserId = _currentUser.UserId,
                MangaThumbnail = S3UrlHelper.ToCloudFrontUrl(avatarUploadUrl?.Url, avatarUploadUrl?.CloundFrontDomain),
                MangaBackground = S3UrlHelper.ToCloudFrontUrl(backgroundUploadUrl?.Url, backgroundUploadUrl?.CloundFrontDomain)
            };

            var response = new CreateMangaResponseDto
            {
                Message = "Tạo manga thất bại",
                AvatarUrl = avatarUploadUrl?.Url,
                BackgroundUrl = backgroundUploadUrl?.Url
            };

            _mangaRepository.Add(newManga);
            var result = await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
                response.Message = $"Tạo thành công, Id: {newManga.Id}";

            return response;
        }
    }
}
