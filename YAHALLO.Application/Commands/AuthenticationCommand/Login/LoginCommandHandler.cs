using MediatR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IJwtService _token;
        private readonly IIPLookupService _ipLookup;
        public LoginCommandHandler(IUserRepository userRepository, IUserTokenRepository userTokenRepository, IJwtService token, IIPLookupService ipLookup   )
        {
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _token = token;
            _ipLookup = ipLookup;
        }
        public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            (string? country, string? city) = string.IsNullOrEmpty(request.IpAddress)
               ? (string.Empty, string.Empty)
               : _ipLookup.Lookup(request.IpAddress);


            var user = await _userRepository.FindSelectAsync(x => x
                .Where(u => u.UserName == request.UserName)
                .Select(t => new
                {
                    Id = t.Id,
                    DisplayName = t.DisplayName,
                    AvatarThumbnail = t.AvatarThumbnail,
                    Password = t.Password,  
                    Level = t.Level,
                    UserRoleEntities = t.UserRoleEntities.Select(r => new UserRoleEntity
                    { 
                        RoleEntity = r.RoleEntity
                    }).ToList(),
                }));

            if (user == null)
                throw new NotFoundException("Tên đăng nhập không chính xác");

            var checkPassword = _userRepository.VerifyPassword(user.Password, request.Password);
            if (checkPassword == false)
                throw new NotFoundException("Mật khẩu không chính xác");

            const int maxActiveSessions = 10; 
            var userToken = await _userTokenRepository.CountAsync(x => x.UserId == user.Id && x.ExpiredRefreshToken > DateTime.UtcNow, cancellationToken);
            if (userToken > maxActiveSessions)
                throw new UnauthorizedAccessException("Bạn đã đăng nhập tối đa số thiết bị cho phép. Vui lòng đăng xuất bớt thiết bị khác");

            var accessToken = _token.CreateToken(user.Id, user.Level, user.UserRoleEntities.Select(x => x.RoleEntity.RoleCode.ToString()).ToList());
            var refreshToken = _token.GenerateRefreshToken();

            var newUserToken = new UserTokenEntity
            {
                UserId = user.Id,
                RefreshToken = _token.HashToken(refreshToken),
                ExpiredRefreshToken = DateTime.UtcNow.AddDays(7),
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent,
                DeviceName = request.DeviceName,
                LoginLocation = $"{city}, {country}",
            };

            _userTokenRepository.Add(newUserToken);
            var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
                throw new UnAuthorizeException("User token cannot create");

            return new AuthResult(
                new LoginResponse
                {
                    Id = user.Id,
                    AvatarUri = user.AvatarThumbnail,
                    Name = user.DisplayName,
                    Roles = user.UserRoleEntities.Select(r => r.RoleEntity.RoleName).ToList(),
                    Level = user.Level,
                    SessionId = newUserToken.Id
                }, accessToken, refreshToken);
        }
    }
}
