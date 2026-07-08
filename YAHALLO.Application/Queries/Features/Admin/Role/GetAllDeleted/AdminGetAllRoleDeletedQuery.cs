using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Role.GetAllDeleted
{
    public sealed class AdminGetAllRoleDeletedQuery: IRequest<List<AdminRoleDto>>
    {
    }
}
