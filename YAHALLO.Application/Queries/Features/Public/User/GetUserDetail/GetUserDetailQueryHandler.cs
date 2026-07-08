using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.User.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailDto>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRepository _userRepository;
        public GetUserDetailQueryHandler(ICurrentUserService currentUser, IUserRepository userRepository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
        }       
        public async Task<UserDetailDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff)
                throw new AccessViolationException("You do not have permission to view user details.");

            var user = await _userRepository.FindSelectAsync(x => x
                .Where(u => u.Id == request.UserId)
                .Select(t => new UserDetailDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    DisplayName = t.DisplayName,
                    Avatar = t.AvatarThumbnail,
                    Background = t.BackgroundThumbnail,
                    Email = t.Email,
                    EmailConfirmed = t.EmailConfirm,  
                    Phone = t.PhoneNumber,
                    Level = t.Level,
                    Status = t.Status,
                    LastUpdateTime = t.LastActiveTime,
                    CreateDate = t.CreateDate
                }),
                cancellationToken);

            if (user == null)
                throw new NotFoundException($"Do not find user with Id {request.UserId}");

            return user;
        }
    }
}
