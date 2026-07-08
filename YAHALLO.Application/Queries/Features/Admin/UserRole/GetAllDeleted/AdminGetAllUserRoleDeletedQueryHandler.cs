using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.UserRole.GetAllDeleted
{
    public sealed class AdminGetAllUserRoleDeletedQueryHandler : IRequestHandler<AdminGetAllUserRoleDeletedQuery, List<AdminUserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public AdminGetAllUserRoleDeletedQueryHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public async Task<List<AdminUserRoleDto>> Handle(AdminGetAllUserRoleDeletedQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _userRoleRepository
               .FindAllSelectAsync(x => x
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
            return userRoles;
        }
    }
}
