using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Services.MailService.Models;
using YAHALLO.Application.Services.MailService.Service;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

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
        private readonly IUnTrustEmailRepository _unTrustEmailRepository;
        private readonly IUnTrustPhoneRepository _unTrustPhoneRepository;
        private readonly IUserBlacklistRepository _userBlacklistRepository;
        private readonly IPendingRegistrationRepository _pendingRegistrationRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStorageService<UserAvatar> _avatarStorage;
        private readonly IStorageService<UserBackground> _backgrondStorage;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUser,
            IUserRoleRepository userRole,
            IRoleRepository roleRepository,
            IEmailService emailService,
            ICurrentContextService context,
            IUnTrustEmailRepository unTrustEmailRepository,
            IUnTrustPhoneRepository unTrustPhoneRepository, 
            IUserBlacklistRepository userBlacklistRepository,
            IPendingRegistrationRepository pendingRegistrationRepository,   
            ICountryRepository countryRepository,
            IStorageService<UserAvatar> avatarStorage,
            IStorageService<UserBackground> backgrondStorage
            )
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _userRoleRepository = userRole;
            _roleRepository = roleRepository;
            _emailServices = emailService;
            _unTrustEmailRepository = unTrustEmailRepository;
            _unTrustPhoneRepository = unTrustPhoneRepository;   
            _userBlacklistRepository = userBlacklistRepository; 
            _pendingRegistrationRepository = pendingRegistrationRepository; 
            _countryRepository = countryRepository; 
            _context = context;
            _avatarStorage = avatarStorage;
            _backgrondStorage = backgrondStorage;
        }
        public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.Email);
            ArgumentNullException.ThrowIfNullOrEmpty(request.PhoneNumber);
            ArgumentException.ThrowIfNullOrEmpty(request.CountryId);

            var country = await _countryRepository.FindAsync(x => x.Id == request.CountryId, cancellationToken);
            if (country == null)
                throw new InvalidOperationException("Invalid country");

            if (!ValidateHelper.IsEmailValidate(request.Email))
                throw new InvalidDataException("Invalid email");

            var email = NormalizeHelper.NormalizeEmail(request.Email);
            var phone = NormalizeHelper.NormalizePhoneNumber(request.PhoneNumber, country.Name);

                var checkExists = await _userRepository.FindAllAsync(
                    x => x.Email == email 
                    || x.UserName == request.UserName 
                    || x.PhoneNumber == phone, cancellationToken);

            if (checkExists.Any(x => x.Email == email))
                throw new ConflictException("Email này đã được sử đụng");

            if (checkExists.Any(x => x.UserName == request.UserName))
                throw new ConflictException("Tên đăng nhập này đã được sử đụng");

            if (checkExists.Any(x => x.PhoneNumber == phone))
                throw new ConflictException("Số điện thoại này đã được sử đụng");

            var blocked =
                await _userBlacklistRepository.AnyAsync(x => x.User.Email == email || x.User.PhoneNumber == phone, cancellationToken)
                || await _unTrustEmailRepository.AnyAsync(x => x.Email == email, cancellationToken)
                || await _unTrustPhoneRepository.AnyAsync(x => x.Phone == phone, cancellationToken);

            if (blocked)
                return await HandleUnTrustUser(email, phone, request, cancellationToken);

            S3Response? avatarResponse = null;
            if (request.Avatar != null)
            {
                avatarResponse = await _avatarStorage.CreateSignedURL(new UserAvatar
                {
                    FileName = request.Avatar.FileName,
                    ContentType = request.Avatar.ContentType,
                    FileSize = request.Avatar.Length,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            }
            S3Response? backgroundResponse = null;
            if (request.Background != null)
            {
                backgroundResponse = await _backgrondStorage.CreateSignedURL(new UserBackground
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
                Email = email,
                PhoneNumber = phone,
                UserName = request.UserName,
                Password = _userRepository.HashPassword(request.Password),
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.UtcNow,
                Status = UserStatus.None,
                Level = UserLevel.One,
                CountryId = country.Id,
                AvatarThumbnail = S3UrlHelper.ToCloudFrontUrl(avatarResponse?.Url, avatarResponse?.CloundFrontDomain),
                BackgroundThumbnail = S3UrlHelper.ToCloudFrontUrl(backgroundResponse?.Url, backgroundResponse?.CloundFrontDomain),  
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
                UserId = user.Id,   
                Message = $"Tạo tài khỏan thành công",
                AvatarUrl = avatarResponse?.Url,
                BackgroundUrl = backgroundResponse?.Url,
            };
            if (result > 0)
            {
                List<string> listSender = new List<string>() { user.Email };
                var token = _emailServices.GenerateEmailToken(user.Id);
                var route = _context.HttpContext + $"services/confirm-email?token={token}&userid={user.Id}";
                _emailServices.SendEmailWithCSS(new Services.MailService.Models.Message(listSender, "Xác Thực Email",
                    "Yêu cầu xác thực cho việc đăng ký tài khoản", route));
                response.Message = $"Một Emaill xác thực đã được gửi đến email {user.Email}. Vui lòng xác nhận để kích hoạt tài khoản";
            }
            else
            {
                response.Message = $"Tạo tài khoản thất bại";
            }

            return response; 
        }
        private async Task<CreateUserResponseDto> HandleUnTrustUser(string email, string phone, CreateUserCommand command, CancellationToken cancenllationToken)
        {
            var existedPending = await _pendingRegistrationRepository.AnyAsync(
                x => x.Status == ReviewStatus.Pending && (x.Email == email || x.PhoneNumber == command.PhoneNumber), cancenllationToken);
            if (existedPending) 
                return new CreateUserResponseDto
                {
                    Message = "Thông tin tài khoản có một số vấn đề, chúng tôi sẽ tiến hành kiểm tra lại  và phản hồi qua email sớm nhất có thể"
                };

            var pending = new PendingRegistrationEntity
            {
                FirstName = command.FirstName,
                LastName = command.LastName,    
                Email = email,
                PhoneNumber = phone,
                UserName = command.UserName,
                CountryId = command.CountryId,  
                HashedPassword = _userRepository.HashPassword(command.Password),
                MatchReason = "Email or phone in blacklist or untrust",
                MatchedSource = "Validate",
                Status = ReviewStatus.Pending
            };
            var response = new CreateUserResponseDto
            {
                UserId = pending.Id,
                Message = $"Tạo tài khoản thất bại",
            };
            _pendingRegistrationRepository.Add(pending);
            var result = await _pendingRegistrationRepository.UnitOfWork.SaveChangesAsync(cancenllationToken);
            if (result > 0)
                response.Message = "Thông tin tài khoản có một số vấn đề, chúng tôi sẽ tiến hành kiểm tra lại  và phản hồi qua email sớm nhất có thể";
            return response;
        }
    }
}
