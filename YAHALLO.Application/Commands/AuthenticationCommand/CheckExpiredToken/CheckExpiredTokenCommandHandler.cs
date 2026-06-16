using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Queries.UserRoleQuery;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Domain.Entities;
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
            var userToken = await _userTokenRepository
                .FindSelectAsync(x => x
                    .Where(x => x.RefreshToken == request.Refeshtoken)
                    .Select(t => new UserTokenEntity
                    {
                        Id = t.Id,
                        AccessToken = t.AccessToken,
                        CreateDate = t.CreateDate,
                        DeleteDate = t.DeleteDate,
                        ExpiredRefreshToken = t.ExpiredRefreshToken,
                        IdUserCreate = t.IdUserCreate,
                        IdUserUpdate = t.IdUserUpdate,
                        IdUserDelete = t.IdUserDelete,
                        RefreshToken = t.RefreshToken,
                        UpdateDate = t.UpdateDate,
                        UserEntity = t.UserEntity,
                    }),
                cancellationToken);
            if (userToken != null)
            {
                if (DateTime.TryParse(userToken.ExpiredRefreshToken, out DateTime expired))
                {
                    if (expired > DateTime.UtcNow)
                    {
                        return new LoginResponse(userToken.Id, userToken?.UserEntity.AvatarThumbnail, userToken?.UserEntity.DisplayName, userToken?.AccessToken, userToken?.RefreshToken);
                    }
                    else
                    {
                        var roles = await _userRoleRepository.FindAllSelectAsync(x => x
                            .Where(x => x.UserId == userToken.Id)
                            .Select(r => new UserRoleDto
                            {
                                RoleId = r.RoleId,
                                UserId = r.UserId,
                                RoleName = r.RoleEntity.RoleName,
                                UserName = r.UserEntity.DisplayName,
                                RoleCode = r.RoleEntity.RoleCode,   
                            })
                            , cancellationToken);

                        var newToken = _jwtService.CreateToken(userToken.Id, userToken.UserEntity.Level, roles.Select(x => x.RoleCode.ToString()).ToList());
                        if (newToken == null) throw new Exception("Tạo token thất bại");
                        var newRefeshToken = _jwtService.GenerateRefreshToken();
                        userToken.AccessToken = newToken;
                        userToken.RefreshToken = newRefeshToken;
                        userToken.ExpiredRefreshToken = DateTime.UtcNow.AddDays(1).ToString();

                        var u = await _userTokenRepository.FindAsync(x => x.Id == userToken.Id, cancellationToken);
                        _userTokenRepository.Update(userToken);
                        var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                        if (result > 0)
                        {
                            return new LoginResponse(userToken.Id, userToken?.UserEntity.AvatarThumbnail, userToken?.UserEntity.DisplayName, userToken!.AccessToken, userToken.RefreshToken);
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
