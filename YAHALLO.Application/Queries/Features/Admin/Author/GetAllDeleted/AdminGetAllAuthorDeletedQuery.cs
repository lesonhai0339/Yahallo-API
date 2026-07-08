using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeleted
{
    public sealed class AdminGetAllAuthorDeletedQuery: IRequest<List<AdminAuthorDto>>
    {
    }
}
