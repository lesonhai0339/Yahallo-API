using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Public.Blog.Filter
{
    public sealed class FilterBlogQuery: IRequest<PagedResult<BlogDto>>
    {
        public int PageNo { get; set; } 
        public int PageSize { get; set; }
        public string? BlogId { get; set; }  
        public string? ParentId { get;set; }
        public string? Title { get; set; }  
    }
}
