using MediatR;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Services.MailService.Service;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailServices;
        private readonly ICurrentContextService _context;
        private readonly IStorageService<UserAvatar> _avatarStorage;
        private readonly IStorageService<UserBackground> _backgrondStorage;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUser,
            IUserRoleRepository userRole,
            IRoleRepository roleRepository,
            IEmailService emailService,
            ICurrentContextService context,
            IStorageService<UserAvatar> avatarStorage,
            IStorageService<UserBackground> backgrondStorage
            )
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _userRoleRepository = userRole;
            _roleRepository = roleRepository;
            _emailServices = emailService;
            _context = context;
            _avatarStorage = avatarStorage;
            _backgrondStorage = backgrondStorage;
        }
        public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await _userRepository.FindAllAsync(x => x.Email == request.Email || x.UserName == request.UserName, cancellationToken);
            if (checkExists.Any(x => x.Email == request.Email))
                throw new NotFoundException("Email này đã được sử đụng");

            if (checkExists.Any(x => x.UserName == request.UserName))
                throw new NotFoundException("Tên đăng nhập này đã được sử đụng");

            if (checkExists.Any(x => x.PhoneNumber == request.PhoneNumber))
                throw new NotFoundException("Số điện thoại này đã được sử đụng");

            string avatarUploadUrl = string.Empty; 
            if(request.Avatar != null)
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
                //test for upload to s3
                backgroundUploadUrl = await _backgrondStorage.CreateSignedURL(new UserBackground
                {
                    FileName = request.Background.FileName,
                    ContentType = request.Background.ContentType,
                    FileSize = request.Background.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }

            var user = new UserEntity
            {
                DisplayName = (request.FirstName + " " + request.LastName).ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber ?? null,
                UserName = request.UserName,
                Password = _userRepository.HashPassword(request.Password),
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,
                Status = UserStatus.None,
                Level = UserLevel.One
            };

            var oldPassword= new UserOldPasswordEntity(user);
            oldPassword.AddNew(request.Password);
            user.OldPasswords = oldPassword;
            _userRepository.Add(user);

            var role = await _roleRepository.FindAsync(x => x.RoleCode == 2, cancellationToken);
            var userRole = new UserRoleEntity { UserId = user.Id, RoleId = role!.Id};
            _userRoleRepository.Add(userRole);

            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var response = new CreateUserResponseDto
            {
                Message = $"Tạo tài khỏa thất bại",
                AvatarUrl = avatarUploadUrl,
                BackgroundUrl = backgroundUploadUrl,
            };
            if (result > 0)
            {
                List<string> listSender= new List<string>() { user.Email };
                var token= _emailServices.GenerateEmailToken(user.Id);
                var route = _context.HttpContext + $"services/confirm-email?token={token}&userid={user.Id}";
                _emailServices.SendEmailWithCSS(new Services.MailService.Models.Message(listSender, "Xác Thực Email",
                    "Yêu cầu xác thực cho việc đăng ký tài khoản", route));
                response.Message = $"Một Emaill xác thực đã được gửi đến email {user.Email}. Vui lòng xác nhận để kích hoạt tài khoản";
            }
           return response; 
        }
    }
}
