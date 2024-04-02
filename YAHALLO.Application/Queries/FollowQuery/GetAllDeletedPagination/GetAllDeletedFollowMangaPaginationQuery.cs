using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.FollowQuery.GetAllDeletedPagination
{
    public class GetAllDeletedFollowMangaPaginationQuery: IRequest<PagedResult<FollowMangaDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllDeletedFollowMangaPaginationQuery(
            int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
    }
}
