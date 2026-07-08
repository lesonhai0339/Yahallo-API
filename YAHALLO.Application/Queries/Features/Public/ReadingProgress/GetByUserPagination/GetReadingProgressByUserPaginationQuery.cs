using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress;
using YAHALLO.Domain.Enums.ReadingProgress;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUserPagination
{
    public class GetReadingProgressByUserPaginationQuery: IRequest<PagedResult<ReadingProgressDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }   
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
        public ReadingProgressSortBy SortBy { get; set; }
        public bool ReverseSort { get; set; }   
    }
}
