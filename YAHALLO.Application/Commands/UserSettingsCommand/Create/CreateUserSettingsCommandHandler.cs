using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Create
{
    public class CreateUserSettingsCommandHandler : IRequestHandler<CreateUserSettingsCommand, CreateUserSettingResult>
    {
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IStorageService<UserSettingsBackground> _storageService;
        public CreateUserSettingsCommandHandler(IUserSettingsRepository userSettingsRepository, ICurrentUserService currentUser, IStorageService<UserSettingsBackground> storageService)
        {
            _userSettingsRepository = userSettingsRepository;
            _currentUser = currentUser;
            _storageService = storageService;
        }

        public async Task<CreateUserSettingResult> Handle(CreateUserSettingsCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Invalid user");

            var userSettings = new UserSettingsEntity
            {
                UserId = _currentUser.UserId,

                Language = request.Language,
                Theme = request.Theme,
                BgOpacity = request.BgOpacity,
                BgBlur = request.BgBlur,

                FontFamily = request.FontFamily,
                FontColor = request.FontColor,
                FontSize = request.FontSize,
                FontWeight = request.FontWeight,

                ListView = request.ListView,
                PageSize = request.PageSize,

                ProgressReadMode = request.ProgressReadMode,
                RetentionDays = request.RetentionDays,
                MaxEntries = request.MaxEntries,
            };
            S3Response? bg = null;
            if (request.BgImage != null)
            {
                bg = await _storageService.CreateSignedURL(new UserSettingsBackground
                {
                    Id = userSettings.Id,
                    FileName = request.BgImage.FileName,
                    ContentType = request.BgImage.ContentType,
                    FileSize = request.BgImage.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            var imageUrl = S3UrlHelper.ToCloudFrontUrl(bg?.Url, bg?.CloundFrontDomain);
            userSettings.BgImageUrl = imageUrl;

            _userSettingsRepository.Add(userSettings);
            var result = await _userSettingsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
                throw new Exception("Failed to create new user settings");

            return new CreateUserSettingResult(UploadUrl: bg?.Url, AccessUrl: imageUrl);
        }
    }
}
