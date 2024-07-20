using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllDeteledPagination
{
    public class GetAllCommentDeletedPaginationQuery: IRequest<PagedResult<CommentDto>>
    {
        public int PageNumber { get;set; }  
        public int PageSize { get;set; }
        public GetAllCommentDeletedPaginationQuery() { }
        public GetAllCommentDeletedPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }   
    }
}
