using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetCatalog
{
    public class GetMangaCatalogQuery : IRequest<PagedResult<MangaDto>>
    {
        public GetMangaCatalogType Type { get; set; } = GetMangaCatalogType.Newest;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}

