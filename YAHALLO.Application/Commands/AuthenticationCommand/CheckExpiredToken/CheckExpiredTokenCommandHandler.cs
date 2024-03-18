using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Services;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommandHandler : IRequestHandler<CheckExpiredTokenCommand, LoginRespone>
    {
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IJwtService _jwtService;
        private readonly IUserRoleRepository _userRoleRepository;
        public CheckExpiredTokenCommandHandler(
            IUserTokenRepository userTokenRepository, 
            IJwtService jwtService,
            IUserRoleRepository userRoleRepository)
        {
            _userTokenRepository = userTokenRepository;
            _jwtService = jwtService;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<LoginRespone> Handle(CheckExpiredTokenCommand request, CancellationToken cancellationToken)
        {
            var checkRefeshToken = await _userTokenRepository.FindAsync(x => x.RefeshToken == request.Refeshtoken, cancellationToken);
            if (checkRefeshToken != null)
            {
                if (DateTime.TryParse(checkRefeshToken.ExpiredRefeshToken, out DateTime expired))
                {
                    if (expired > DateTime.UtcNow)
                    {
                        return new LoginRespone(checkRefeshToken.Id, checkRefeshToken.AccessToken, checkRefeshToken.RefeshToken);
                    }
                    else
                    {
                        var roles = await _userRoleRepository.FindAllAsync(x => x.UserId == checkRefeshToken.Id, cancellationToken);
                        var newToken = _jwtService.CreateToken(checkRefeshToken.Id, roles.Select(x => x.RoleId).ToList());
                        if (newToken == null) throw new Exception("Tạo token thất bại");
                        var newRefeshToken = _jwtService.GenerateRefreshToken();
                        checkRefeshToken.AccessToken = newToken;
                        checkRefeshToken.RefeshToken = newRefeshToken;
                        checkRefeshToken.ExpiredRefeshToken = DateTime.Now.AddDays(1).ToString();
                        _userTokenRepository.Update(checkRefeshToken);
                        var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                        if (result > 0)
                        {
                            return new LoginRespone(checkRefeshToken.Id, checkRefeshToken.AccessToken, checkRefeshToken.RefeshToken);
                        }
                        else
                        {
                            throw new NotFoundException("Lỗi trong quá trình lưu dữ liệu");
                        }
                    }
                }
                throw new NotFoundException("Thất bại");
            }
            throw new NotFoundException("Không tìm thấy");
        }
    }
}
