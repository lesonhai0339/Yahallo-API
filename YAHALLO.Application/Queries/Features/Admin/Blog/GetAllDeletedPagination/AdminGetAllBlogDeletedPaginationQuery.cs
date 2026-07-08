using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.GetAllDeletedPagination
{
    public sealed class GetAllBlogDeletedPaginationQuery: IRequest<PagedResult<AdminBlogDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }  
      
    }
}
