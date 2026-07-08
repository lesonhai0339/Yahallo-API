using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeleted
{
    public sealed class AdminGetAllUserDeletedQuery : IRequest<List<AdminUserDto>>
    {
    }
}
