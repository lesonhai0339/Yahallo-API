using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.UserRole.GetAllDeleted
{
    public sealed class AdminGetAllUserRoleDeletedQuery: IRequest<List<AdminUserRoleDto>>
    {
    }
}
