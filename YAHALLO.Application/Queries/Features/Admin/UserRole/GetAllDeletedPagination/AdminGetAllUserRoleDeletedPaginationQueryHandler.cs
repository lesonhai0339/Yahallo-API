using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.UserRole.GetAllDeletedPagination
{
    public sealed class AdminGetAllUserRoleDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllUserRoleDeletedPaginationQuery, PagedResult<AdminUserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public AdminGetAllUserRoleDeletedPaginationQueryHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public async Task<PagedResult<AdminUserRoleDto>> Handle(AdminGetAllUserRoleDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _userRoleRepository
               .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(u => !string.IsNullOrEmpty(u.IdUserDelete) && u.DeleteDate.HasValue)
                    .Select(t => new AdminUserRoleDto
                    {
                        UserId = t.UserId,
                        UserName = t.UserEntity.DisplayName,
                        RoleId = t.RoleId,
                        RoleName = t.RoleEntity.RoleName,
                        RoleCode = t.RoleEntity.RoleCode,
                    }),
                    cancellationToken,
                    ignoreQueryFilters: true);
            return userRoles.MapToPagedResult(x => x);
        }
    }
}
