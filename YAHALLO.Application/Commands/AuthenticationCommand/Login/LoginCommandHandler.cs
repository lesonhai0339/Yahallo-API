using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginRespone>
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
        public async Task<LoginRespone> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var checkUserExist= await _userRepository.FindAsync(x=> x.UserName == request.UserName, cancellationToken); 
            if(checkUserExist == null)
            {
                throw new NotFoundException("Tên đăng nhập không chính xác");
            }
            var checkPassword = _userRepository.VerifyPassword(checkUserExist.Password, request.Password);
            if(checkPassword == false)
            {
                throw new NotFoundException("Mật khẩu không chính xác");
            }
            var checkExistToken = await _userTokenRepository.FindAsync(x => x.Id == checkUserExist.Id, cancellationToken);
            if(checkExistToken != null)
            {
                if(DateTime.TryParse(checkExistToken.ExpiredRefeshToken, out DateTime expried))
                {
                    if(expried > DateTime.Now)
                    {
                        return new LoginRespone(checkExistToken.Id, checkExistToken.AccessToken, checkExistToken.RefeshToken);
                    }
                    else
                    {
                        var newtoken = _token.CreateToken(checkUserExist.Id,checkUserExist.Level, checkUserExist.UserRoleEntities.Select(x => x.RoleEntity.RoleCode.ToString()).ToList());
                        if (newtoken != null)
                        {
                            checkExistToken.AccessToken = newtoken;
                            checkExistToken.RefeshToken = _token.GenerateRefreshToken();
                            checkExistToken.ExpiredRefeshToken = DateTime.Now.AddDays(1).ToString();                        
                            _userTokenRepository.Update(checkExistToken);
                            var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                            if (result > 0)
                            {
                                return new LoginRespone(checkExistToken.Id, checkExistToken.AccessToken, checkExistToken.RefeshToken);
                            }
                            else
                            {
                                throw new UnAuthorizeException("Đăng nhập thất bại");
                            }
                        }
                    }
                }
                throw new UnAuthorizeException("Đăng nhập thất bại");
            }
            else
            {
                var token = _token.CreateToken(checkUserExist.Id, checkUserExist.UserRoleEntities.Select(x => x.RoleEntity.RoleCode.ToString()).ToList());
                if (token != null)
                {
                    var refeshToken = _token.GenerateRefreshToken();
                    var usertoken = new UserTokenEntity
                    {
                        Id = checkUserExist.Id,
                        AccessToken = token,
                        RefeshToken = refeshToken,
                        ExpiredRefeshToken = DateTime.Now.AddDays(1).ToString()
                    };
                    _userTokenRepository.Add(usertoken);
                    var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result > 0)
                    {
                        return new LoginRespone(checkUserExist.Id, token, refeshToken);
                    }
                    else
                    {
                        throw new UnAuthorizeException("Đăng nhập thất bại");
                    }
                }
                throw new UnAuthorizeException("Đăng nhập thất bại");
            }
        }
    }
}
