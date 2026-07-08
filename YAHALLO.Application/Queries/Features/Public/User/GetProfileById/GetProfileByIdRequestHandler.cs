using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Enums.ReactionEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.User.GetProfileById
{
    public class GetProfileByIdRequestHandler : IRequestHandler<GetProfileByIdRequest, UserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        public GetProfileByIdRequestHandler(IUserRepository userRepository, ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<UserProfileDto> Handle(GetProfileByIdRequest request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.IsInRoleAsync(Policies.ModOrAdmin);
            var targetId = isStaff && !string.IsNullOrEmpty(request.Id)
                ? request.Id
                : _currentUser.UserId;


            var user = await _userRepository.FindSelectAsync(x =>
                x.Where(u => u.Id == targetId)
                    .Select(t => new UserProfileDto
                    {
                        Id = t.Id,
                        Avatar = t.AvatarThumbnail,
                        Background = t.BackgroundThumbnail,
                        CreateDate = t.CreateDate,
                        DisplayName = t.DisplayName,
                        Email = t.Email,
                        Level = t.Level,
                        MangaFavoriteCount = t.Reactions.Count(c => (ReactionEnum?)c.Reaction == ReactionEnum.Like),
                        MangaFollowingCount = t.FollowEntities.Count(),
                        PhoneNumber = t.PhoneNumber,
                        Roles = t.UserRoleEntities.Select(r => r.RoleEntity.RoleName).ToList(),
                        Status = t.Status
                    })
                , cancellationToken);
            if (user == null)
                throw new Exception("No user found!");
            return user;
        }
    }
}
