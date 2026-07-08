using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.ReadingProgress;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUserPagination
{
    public class FilterReadingProgressQuery: IRequest<PagedResult<ReadingProgressDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }   
        public string? MangaId { get; set; }
        public ReadingProgressSortBy SortBy { get; set; }
        public bool ReverseSort { get; set; }   
    }
}
