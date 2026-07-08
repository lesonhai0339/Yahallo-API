using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Tag.GetAllDeleted
{
    public sealed class AdminGetAllTagDeletedQuery: IRequest<List<AdminTagDto>>
    {
    }
}
