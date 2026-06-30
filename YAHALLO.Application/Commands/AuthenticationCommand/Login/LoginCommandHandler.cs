using MediatR;
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
        public LoginCommandHandler(IUserRepository userRepository, IUserTokenRepository userTokenRepository, IJwtService token)
        {
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _token = token;
        }
        public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var checkUserExist = await _userRepository.FindSelectAsync(x => x
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

            if (checkUserExist == null)
                throw new NotFoundException("Tên đăng nhập không chính xác");

            var checkPassword = _userRepository.VerifyPassword(checkUserExist.Password, request.Password);
            if (checkPassword == false)
                throw new NotFoundException("Mật khẩu không chính xác");

            var checkExistToken = await _userTokenRepository.FindAsync(x => x.UserId == checkUserExist.Id, cancellationToken);



            if (checkExistToken != null)
            {
                var accessToken = _token.CreateToken(checkUserExist.Id, checkUserExist.Level, checkUserExist.UserRoleEntities.Select(x => x.RoleEntity.RoleCode.ToString()).ToList());
                if (accessToken != null)
                {
                    var refreshToken = _token.GenerateRefreshToken();
                    
                    checkExistToken.RefreshToken = _token.HashToken(refreshToken);
                    checkExistToken.ExpiredRefreshToken = DateTime.UtcNow.AddDays(7);

                    _userTokenRepository.Update(checkExistToken);
                    var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                    if (result > 0)
                    {
                        return new AuthResult(new LoginResponse
                        {
                            UserId = checkExistToken.UserId,
                            AvatarUri = checkUserExist.AvatarThumbnail,
                            Name = checkUserExist.DisplayName,
                            Roles = checkUserExist.UserRoleEntities.Select(r => r.RoleEntity.RoleName).ToList(),
                            Level = checkUserExist.Level
                        }, accessToken, refreshToken);
                    }
                }
                throw new UnAuthorizeException("Đăng nhập thất bại");
            }
            else
            {
                var token = _token.CreateToken(checkUserExist.Id, checkUserExist.Level, checkUserExist.UserRoleEntities.Select(x => x.RoleEntity.RoleCode.ToString()).ToList());
                if (token != null)
                {
                    var refreshToken = _token.GenerateRefreshToken();
                    var userToken = new UserTokenEntity
                    {
                        UserId = checkUserExist.Id,
                        RefreshToken = _token.HashToken(refreshToken),
                        ExpiredRefreshToken = DateTime.UtcNow.AddDays(7)
                    };
                    _userTokenRepository.Add(userToken);
                    var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result > 0)
                    {
                        return new AuthResult(
                            new LoginResponse
                            {
                                UserId = checkUserExist.Id,
                                AvatarUri = checkUserExist.AvatarThumbnail,
                                Name = checkUserExist.DisplayName,
                                Roles = checkUserExist.UserRoleEntities.Select(r => r.RoleEntity.RoleName).ToList(),
                                Level = checkUserExist.Level,
                            }, token, refreshToken);
                    }
                    else
                    {
                        throw new UnAuthorizeException("Đăng nhập thất bại");
                    }
                }
                throw new UnAuthorizeException("Đăng nhập thất bại");
            }
        }
    }
}
