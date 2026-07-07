using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeteledPagination
{
    public sealed class GetAllCommentDeletedPaginationQuery: IRequest<PagedResult<AdminCommentDto>>
    {
        public int PageNumber { get;set; }  
        public int PageSize { get;set; }
       
    }
}
