using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAllDeletedPagination
{
    public class GetAllDeletedMangaRatingPaginationQuery: IRequest<PagedResult<MangaRatingDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get;set; }
        public GetAllDeletedMangaRatingPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }   
    }
}
