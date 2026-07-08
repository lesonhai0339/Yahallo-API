//AI generated
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Tag;

namespace YAHALLO.Application.Queries.Features.Public.Tag.FilterTag
{
    public class FilterTagQuery : IRequest<PagedResult<TagDto>>
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
