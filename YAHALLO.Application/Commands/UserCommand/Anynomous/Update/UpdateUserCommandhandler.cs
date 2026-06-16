
using MediatR;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Update
{
    public class UpdateUserCommandhandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStorageService<UserAvatar> _avatarStorage;
        private readonly IStorageService<UserBackground> _backgrondStorage;
        public UpdateUserCommandhandler(
            IUserRepository userRepository,
            IStorageService<UserAvatar> avatarStorage,
            IStorageService<UserBackground> backgrondStorage
            )
        {
            _userRepository = userRepository;
            _avatarStorage = avatarStorage;
            _backgrondStorage = backgrondStorage;   
        }
        public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.Id);

            var user = await _userRepository
                .FindAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
                throw new NotFoundException($"Không tìm thấy thành viên với Id {request.Id}");

            user.DisplayName = request.DisplayName ?? user.DisplayName;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            string avatarUploadUrl = string.Empty;
            if (request.Avatar != null)
            {
                avatarUploadUrl = await _avatarStorage.CreateSignedURL(new UserAvatar
                {
                    FileName = request.Avatar.FileName,
                    ContentType = request.Avatar.ContentType,
                    FileSize = request.Avatar.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            string backgroundUploadUrl = string.Empty;
            if (request.Background != null)
            {
                backgroundUploadUrl = await _backgrondStorage.CreateSignedURL(new UserBackground
                {
                    FileName = request.Background.FileName,
                    ContentType = request.Background.ContentType,
                    FileSize = request.Background.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            _userRepository.Update(user);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            return result > 0 ? new UpdateUserResponseDto{ 
                Id = user.Id,
                DisplayName = user.DisplayName,
                AvatarUrl = avatarUploadUrl,
                BackgroundUrl = backgroundUploadUrl,    
            } : throw new UpdateFailedException($"Cannot update info for user id : {request.Id}");
        }
    }
}
