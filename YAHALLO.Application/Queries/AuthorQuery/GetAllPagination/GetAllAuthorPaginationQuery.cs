using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.AuthorQuery.GetAllPagination
{
    public class GetAllAuthorPaginationQuery: IRequest<PagedResult<AuthorDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllAuthorPaginationQuery() { }
        public GetAllAuthorPaginationQuery(
            int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
    }
}
