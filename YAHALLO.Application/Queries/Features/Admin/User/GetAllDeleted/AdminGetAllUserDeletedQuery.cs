using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeleted
{
    public sealed class GetAllUserDeletedQuery : IRequest<List<AdminUserDto>>
    {
    }
}
