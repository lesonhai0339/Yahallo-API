using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Role.GetAllDeletedPagination
{
    public sealed class AdminGetAllRoleDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllRoleDeletedPaginationQuery, PagedResult<AdminRoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        public AdminGetAllRoleDeletedPaginationQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<PagedResult<AdminRoleDto>> Handle(AdminGetAllRoleDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize, 
                selector: x => x
                    .Where(r => !string.IsNullOrEmpty(r.IdUserDelete) && r.DeleteDate.HasValue)
                    .Select(t => new AdminRoleDto
                    {
                        Id = t.Id,
                        RoleCode = t.RoleCode,
                        RoleDescription = t.RoleDescription,
                        RoleName = t.RoleName,
                    }),
                    cancellation: cancellationToken,
                    ignoreQueryFilters: true);
            return roles.MapToPagedResult(x => x);
        }
    }
}
