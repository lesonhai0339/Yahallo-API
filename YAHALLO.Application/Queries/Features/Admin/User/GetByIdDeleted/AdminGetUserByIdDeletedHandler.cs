using MediatR;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetByIdDeleted
{
    public sealed class AdminGetUserByIdDeletedHandler : IRequestHandler<AdminGetUserByIdDeleted, AdminUserDto>
    {
        private readonly IUserRepository _userRepository;
        public AdminGetUserByIdDeletedHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AdminUserDto> Handle(AdminGetUserByIdDeleted request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .FindSelectAsync(x => x
                    .Where(u => u.Id == request.Id && !string.IsNullOrEmpty(u.IdUserDelete) && u.DeleteDate.HasValue)
                        .Select(t => new AdminUserDto
                        {
                            Id = t.Id,
                            Avatar = t.AvatarThumbnail,
                            Background = t.BackgroundThumbnail,
                            DisplayName = t.DisplayName,
                            Email = t.Email,
                            Level = t.Level,
                            PhoneNumber = t.PhoneNumber,
                            Status = t.Status,
                        }), 
                    cancellationToken,
                    true);
            if (user == null) throw new NotFoundException($"Cannot find user with id {request.Id}");

            return user;
        }
    }
}
