using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetAllPagination
{
    public class GetAllPaginationUserQuery : IRequest<PagedResult<UserDto>>
    {
        public GetAllPaginationUserQuery() { }
        public GetAllPaginationUserQuery(
            int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
