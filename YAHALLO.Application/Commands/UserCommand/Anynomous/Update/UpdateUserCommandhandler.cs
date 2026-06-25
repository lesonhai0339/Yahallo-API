
using MediatR;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Update
{
    public class UpdateUserCommandhandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IStorageService<UserAvatar> _avatarStorage;
        private readonly IStorageService<UserBackground> _backgrondStorage;
        public UpdateUserCommandhandler(
            ICurrentUserService currentUser,    
            IUserRepository userRepository,
            IStorageService<UserAvatar> avatarStorage,
            IStorageService<UserBackground> backgrondStorage
            )
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _avatarStorage = avatarStorage;
            _backgrondStorage = backgrondStorage;   
        }
        public async Task<UpdateUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Unauthorize");


            var user = await _userRepository
                .FindAsync(x => x.Id == _currentUser.UserId, cancellationToken);
            if (user == null)
                throw new NotFoundException("Không tìm thấy thành viên");

            if(!string.IsNullOrWhiteSpace(request.DisplayName))
                user.DisplayName = request.DisplayName ?? user.DisplayName;

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

            S3Response? avatarResponse = null;
            if (request.Avatar != null)
            {
                if (!string.IsNullOrEmpty(user.AvatarThumbnail))
                {
                    var deleted = await _avatarStorage.DeleteFile(new UserAvatar { Id = user.Id }, user.AvatarThumbnail);
                    if (!deleted)
                        throw new Exception("Cannot delete old background");
                }
                avatarResponse = await _avatarStorage.CreateSignedURL(new UserAvatar
                {
                    Id = user.Id,
                    FileName = request.Avatar.FileName,
                    ContentType = request.Avatar.ContentType,
                    FileSize = request.Avatar.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            S3Response? backgroundResponse = null;
            if (request.Background != null)
            {
                if (!string.IsNullOrEmpty(user.BackgroundThumbnail))
                {
                    var deleted = await _backgrondStorage.DeleteFile(new UserBackground { Id = user.Id }, user.BackgroundThumbnail);
                    if (!deleted)
                        throw new Exception("Cannot delete old background");
                }
                backgroundResponse = await _backgrondStorage.CreateSignedURL(new UserBackground
                {
                    Id = user.Id,
                    FileName = request.Background.FileName,
                    ContentType = request.Background.ContentType,
                    FileSize = request.Background.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            var avatar = S3UrlHelper.ToCloudFrontUrl(avatarResponse?.Url!, avatarResponse?.CloundFrontDomain);
            var background = S3UrlHelper.ToCloudFrontUrl(backgroundResponse?.Url!, backgroundResponse?.CloundFrontDomain);
            
            user.AvatarThumbnail = avatar ?? null;
            user.BackgroundThumbnail  = background ?? null;

            _userRepository.Update(user);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            return result > 0 ? new UpdateUserResult
            (
                Id : user.Id,
                DisplayName : user.DisplayName,
                UploadAvatarUrl : avatarResponse?.Url,
                AccessAvatarUrl : avatar,
                UpdaloadBackgroundUrl : backgroundResponse?.Url,
                AccessBackgroundUrl : background
            ) : throw new UpdateFailedException($"Cannot update info for user");
        }
    }
}
