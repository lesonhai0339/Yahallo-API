using MediatR;
using System.Data;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommandHandler : IRequestHandler<CheckExpiredTokenCommand, CheckExpiredResult>
    {
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IJwtService _jwtService;
        public CheckExpiredTokenCommandHandler(
            IUserTokenRepository userTokenRepository, 
            IJwtService jwtService)
        {
            _userTokenRepository = userTokenRepository;
            _jwtService = jwtService;
        }

        public async Task<CheckExpiredResult> Handle(CheckExpiredTokenCommand request, CancellationToken cancellationToken)
        {
            var hashedToken = _jwtService.HashToken(request.Refeshtoken);

            var record = await _userTokenRepository
                .FindSelectAsync(x => x
                    .Where(x => x.RefreshToken == hashedToken)
                    .Select(t => new UserTokenDto
                    {
                        UserId = t.UserId,
                        Avatar = t.UserEntity!.AvatarThumbnail,
                        DisplayName = t.UserEntity.DisplayName,
                        Level = t.UserEntity.Level,
                        Roles =  t.UserEntity.UserRoleEntities.Select(x => new RoleDto 
                                {  
                                    Code=  x.RoleEntity.RoleCode.ToString(), 
                                    Name =  x.RoleEntity.RoleName }
                        ).ToList(),
                        Expired = t.ExpiredRefreshToken,
                        IsRevoked = t.IsRevoked   
                       
                    }),
                    cancellationToken);

            if (record == null
                || record.Expired < DateTime.UtcNow
                || record.IsRevoked)
                throw new UnAuthorizeException("Invalid or expired refresh token" );

            var accessToken = _jwtService.CreateToken(record.UserId, record.Level, record.Roles.Select(x => x.Code).ToList());
            if (accessToken == null) 
                throw new Exception("Tạo token thất bại");

            var refreshToken = _jwtService.GenerateRefreshToken();
            var hashedRefreshToken = _jwtService.HashToken(refreshToken);

            var userToken = await _userTokenRepository.FindAsync(x => x.UserId == record.UserId, cancellationToken);
            if(userToken == null)
                throw new UnAuthorizeException("Not found user token");

            userToken.RefreshToken = hashedRefreshToken;
            userToken.ExpiredRefreshToken = DateTime.UtcNow;
            userToken.UpdateDate = DateTime.UtcNow;
            userToken.IdUserUpdate = userToken.UserId;
            userToken.IsRevoked = false;


            _userTokenRepository.Update(userToken);
            var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
                throw new Exception("Error when check refresh token");
            return new CheckExpiredResult(new LoginResponse
            {
                Id = record.UserId,
                AvatarUri = record.Avatar,
                Name = record.DisplayName,
                Level = record.Level,
                Roles = record.Roles.Select(x => x.Name).ToList(),
                SessionId = userToken.Id
            }, accessToken, refreshToken);
        }
    }
}
