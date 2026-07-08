using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.User.GetMe
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, MeResult>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRepository _userRepository;
        public GetMeQueryHandler(ICurrentUserService currentUser, IUserRepository userRepository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
        }

        public async Task<MeResult> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("");

            var me = await _userRepository.FindSelectAsync(x => x
                    .Where(u => u.Id == _currentUser.UserId)
                    .Select(t => new MeResult
                    {
                        Id = t.Id,
                        Name = t.DisplayName,
                        AvatarUri = t.AvatarThumbnail,
                        Roles = t.UserRoleEntities.Select(x => x.RoleEntity.RoleName).ToList(),
                        Level = t.Level
                    }), cancellationToken);
            if (me == null)
                throw new NotFoundException($"Not found");

            return me;
        }
    }
}
