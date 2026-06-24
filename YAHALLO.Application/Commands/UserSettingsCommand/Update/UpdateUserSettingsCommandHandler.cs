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
using YAHALLO.Domain.Enums.ListView;
using YAHALLO.Domain.Enums.Progress;
using YAHALLO.Domain.Enums.Style;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Update
{
    public class UpdateUserSettingsCommandHandler : IRequestHandler<UpdateUserSettingsCommand, string>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IStorageService<UserSettingsBackground> _storageService;
        public UpdateUserSettingsCommandHandler(ICurrentUserService currentUserService, IUserSettingsRepository userSettingsRepository, IStorageService<UserSettingsBackground> storageService)
        {
            _currentUser = currentUserService;
            _userSettingsRepository = userSettingsRepository;
            _storageService = storageService;
        }

        public async Task<string> Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Unauthorize");

            var setting = await _userSettingsRepository.FindAsync(x => x.UserId == _currentUser.UserId, cancellationToken);
            if (setting == null)
                throw new NotFoundException("Not found setting for current user");

            if(!string.IsNullOrEmpty(setting.BgImageUrl) && request.BgImage != null)
            {
                var deleted = await _storageService.DeleteFile(new UserSettingsBackground { Id = setting.UserId }, setting.BgImageUrl);
                if (!deleted)
                    throw new Exception("Cannot delete old background");
            }

            S3Response? bg = null;
            if (request.BgImage != null)
            {
                bg = await _storageService.CreateSignedURL(new UserSettingsBackground
                {
                    Id = setting.Id,    
                    FileName = request.BgImage.FileName,
                    ContentType = request.BgImage.ContentType,
                    FileSize = request.BgImage.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }

            if(!string.IsNullOrEmpty(request.Language)) setting.Language = request.Language;
            if (request.Theme != null) setting.Theme = (Theme)request.Theme;
            if(bg != null) setting.BgImageUrl = S3UrlHelper.ToCloudFrontUrl(bg?.Url, bg?.CloundFrontDomain);
            if (request.BgOpacity != null) setting.BgOpacity = request.BgOpacity;
            if (request.BgBlur != null) setting.BgBlur = request.BgBlur;
            if (request.FontFamily != null) setting.FontFamily = request.FontFamily;
            if (request.FontColor != null) setting.FontColor = request.FontColor;
            if (request.FontSize != null) setting.FontSize = request.FontSize;
            if (request.FontWeight != null) setting.FontWeight = request.FontWeight;
            if (request.ListView != null) setting.ListView = request.ListView;
            if (request.PageSize != null) setting.PageSize = request.PageSize;
            if (request.ProgressReadMode != null) setting.ProgressReadMode = (ProgressReadMode)request.ProgressReadMode;
            if (request.RetentionDays != null) setting.RetentionDays = (int)request.RetentionDays;
            if (request.MaxEntries != null) setting.MaxEntries = (int)request.MaxEntries;

            _userSettingsRepository.Update(setting);
            var result = await _userSettingsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
                throw new Exception("Failed to create new user settings");

            return bg?.Url ?? string.Empty;

        }
    }
}
