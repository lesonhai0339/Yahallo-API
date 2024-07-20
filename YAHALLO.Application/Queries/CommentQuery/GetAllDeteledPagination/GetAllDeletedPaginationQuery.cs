using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllDeteledPagination
{
    public class GetAllDeletedPaginationQuery: IRequest<PagedResult<CommentDto>>
    {
        public int PageNumber { get;set; }  
        public int PageSize { get;set; }
        public GetAllDeletedPaginationQuery() { }
        public GetAllDeletedPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }   
    }
}
