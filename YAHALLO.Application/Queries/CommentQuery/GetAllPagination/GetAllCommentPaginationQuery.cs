using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllPagination
{
    public class GetAllCommentPaginationQuery: IRequest<PagedResult<CommentDto>>
    {
        public GetAllCommentPaginationQuery() { }
        public GetAllCommentPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get;set; }
        public int PageSize { get;set; }    
    }
}
