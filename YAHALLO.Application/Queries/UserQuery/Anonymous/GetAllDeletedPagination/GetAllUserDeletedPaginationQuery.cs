using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetAllDeletedPagination
{
    public class GetAllUserDeletedPaginationQuery : IRequest<PagedResult<UserDto>>
    {
        public GetAllUserDeletedPaginationQuery() { }
        public GetAllUserDeletedPaginationQuery(
            int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
