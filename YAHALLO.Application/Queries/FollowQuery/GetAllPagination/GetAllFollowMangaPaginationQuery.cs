using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.FollowQuery.GetAllPagination
{
    public class GetAllFollowMangaPaginationQuery: IRequest<PagedResult<FollowMangaDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get; set; }
        public GetAllFollowMangaPaginationQuery(
            int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
    }
}
