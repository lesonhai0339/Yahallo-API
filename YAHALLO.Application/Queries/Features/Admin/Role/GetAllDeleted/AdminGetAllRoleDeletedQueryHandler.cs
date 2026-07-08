using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Role.GetAllDeleted
{
    public sealed class AdminGetAllRoleDeletedQueryHandler : IRequestHandler<AdminGetAllRoleDeletedQuery, List<AdminRoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        public AdminGetAllRoleDeletedQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<AdminRoleDto>> Handle(AdminGetAllRoleDeletedQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository
                .FindAllSelectAsync(x => x
                    .Where(r => !string.IsNullOrEmpty(r.IdUserDelete) && r.DeleteDate.HasValue)
                    .Select(t => new AdminRoleDto
                    {
                        Id = t.Id,
                        RoleCode = t.RoleCode,
                        RoleDescription = t.RoleDescription,    
                        RoleName = t.RoleName,  
                    }), 
                    cancellationToken, 
                    ignoreQueryFilters: true);
            return roles;  
        }
    }
}
