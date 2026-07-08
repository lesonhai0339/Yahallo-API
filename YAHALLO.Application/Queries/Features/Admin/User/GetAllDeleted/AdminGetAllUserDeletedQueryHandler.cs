using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeleted
{
    public sealed class AdminGetAllUserDeletedQueryHandler : IRequestHandler<AdminGetAllUserDeletedQuery, List<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;
        public AdminGetAllUserDeletedQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<AdminUserDto>> Handle(AdminGetAllUserDeletedQuery request, CancellationToken cancellationToken)
        {
            var listUsers = await _userRepository
                .FindAllSelectAsync(x => x
                    .Where(u => !string.IsNullOrEmpty(u.IdUserDelete) && u.DeleteDate.HasValue)
                    .Select(u => new AdminUserDto
                    {
                        Id = u.Id,
                        Avatar = u.AvatarThumbnail,
                        Background = u.BackgroundThumbnail,
                        DisplayName = u.DisplayName,
                        Email = u.Email,
                        Level = u.Level,
                        PhoneNumber = u.PhoneNumber,
                        Status = u.Status,
                    }),
                cancellationToken, 
                true);
            return listUsers;
        }
    }
}
