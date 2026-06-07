//AI generated
using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetLatestUpdated
{
    public class GetLatestUpdatedMangaQuery : IRequest<PagedResult<MangaSumaryDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
