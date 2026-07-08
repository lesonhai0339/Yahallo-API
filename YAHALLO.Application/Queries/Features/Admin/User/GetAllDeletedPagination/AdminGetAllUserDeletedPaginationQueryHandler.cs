using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeletedPagination
{
    public sealed class GetAllUserDeletedPaginationQueryHandler : IRequestHandler<GetAllUserDeletedPaginationQuery, PagedResult<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserDeletedPaginationQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PagedResult<AdminUserDto>> Handle(GetAllUserDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository
                .FindAllSelectAsync(
                pageNo : request.PageNumber,
                pageSize: request.PageSize,
                selector: x => x
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
                cancellation: cancellationToken,
                ignoreQueryFilters: true);

            return users.MapToPagedResult(x => x);
        }
    }
}
