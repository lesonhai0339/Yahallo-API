using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Services;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommandHandler : IRequestHandler<CheckExpiredTokenCommand, LoginResponse>
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

        public async Task<LoginResponse> Handle(CheckExpiredTokenCommand request, CancellationToken cancellationToken)
        {
            var checkRefreshToken = await _userTokenRepository.FindAsync(x => x.RefeshToken == request.Refeshtoken, cancellationToken);
            if (checkRefreshToken != null)
            {
                if (DateTime.TryParse(checkRefreshToken.ExpiredRefeshToken, out DateTime expired))
                {
                    if (expired > DateTime.UtcNow)
                    {
                        return new LoginResponse(checkRefreshToken.Id, checkRefreshToken?.UserEntity.Avatar?.BaseUrl, checkRefreshToken?.UserEntity.DisplayName, checkRefreshToken.AccessToken, checkRefreshToken.RefeshToken);
                    }
                    else
                    {
                        var roles = await _userRoleRepository.FindAllAsync(x => x.UserId == checkRefreshToken.Id, cancellationToken);
                        var newToken = _jwtService.CreateToken(checkRefreshToken.Id, roles.Select(x => x.RoleId).ToList());
                        if (newToken == null) throw new Exception("Tạo token thất bại");
                        var newRefeshToken = _jwtService.GenerateRefreshToken();
                        checkRefreshToken.AccessToken = newToken;
                        checkRefreshToken.RefeshToken = newRefeshToken;
                        checkRefreshToken.ExpiredRefeshToken = DateTime.Now.AddDays(1).ToString();
                        _userTokenRepository.Update(checkRefreshToken);
                        var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                        if (result > 0)
                        {
                            return new LoginResponse(checkRefreshToken.Id, checkRefreshToken?.UserEntity.Avatar?.BaseUrl, checkRefreshToken?.UserEntity.DisplayName, checkRefreshToken!.AccessToken, checkRefreshToken.RefeshToken);
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
