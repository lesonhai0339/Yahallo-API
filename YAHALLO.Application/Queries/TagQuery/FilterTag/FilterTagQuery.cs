//AI generated
using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.TagQuery.FilterTag
{
    public class FilterTagQuery : IRequest<PagedResult<TagDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
