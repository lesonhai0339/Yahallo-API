using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.ReadingProgress;

namespace YAHALLO.Application.Queries.ReadingProgressQuery.GetByUserPagination
{
    public class GetReadingProgressByUserPaginationQuery: IRequest<PagedResult<ReadingProgressDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }   
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
        public ReadingProgressSortBy SortBy { get; set; }
        public bool ReverseSort { get; set; }   
    }
}
