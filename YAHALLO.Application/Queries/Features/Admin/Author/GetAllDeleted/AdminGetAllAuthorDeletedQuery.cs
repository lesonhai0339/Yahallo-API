using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeleted
{
    public sealed class GetAllAuthorDeletedQuery: IRequest<List<AdminAuthorDto>>
    {
    }
}
