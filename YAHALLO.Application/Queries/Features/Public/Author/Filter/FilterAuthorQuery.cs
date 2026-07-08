using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Public.Author.Filter
{
    public class FilterAuthorQuery: IRequest<PagedResult<AuthorDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? Id { get; set; } = null!;
        public string? Name { get; set; }
    }
}
