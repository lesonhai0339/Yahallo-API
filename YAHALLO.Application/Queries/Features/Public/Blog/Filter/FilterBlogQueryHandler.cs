using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Blog.Filter
{
    public class FilterBlogQueryHandler : IRequestHandler<FilterBlogQuery, PagedResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        public FilterBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
    
        public async Task<PagedResult<BlogDto>> Handle(FilterBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository
                 .FindAllSelectAsync(
                    pageNo: request.PageNo, 
                    pageSize: request.PageSize,
                    selector: q =>
                    ApplyFilter(q, request)
                    .Select(x => new BlogDto
                        {
                               Id = x.Id,
                               Content = x.Content,
                               Title = x.Title,
                               Description = x.Description,
                               DisLike = x.DisLike,
                               Like = x.Like,
                               OwnerUserId  = x.UserId,
                               Status = x.Status,
                               Type = x.Type, 
                               ViewCount = x.ViewCount == null ? 0 : x.ViewCount.TotalCount
                        }),
                cancellationToken
                );
            return blogs.MapToPagedResult(x => x);
        }
        private IQueryable<BlogEntity> ApplyFilter(IQueryable<BlogEntity> query, FilterBlogQuery request)
        {
            if (!string.IsNullOrEmpty(request.BlogId)) query = query.Where(x => x.Id == request.BlogId);

            if (!string.IsNullOrEmpty(request.ParentId)) query = query.Where(x => x.UserId == request.ParentId);

            var title = request.Title?.Trim();
            if (!string.IsNullOrEmpty(title)) query = query.Where(x => x.Title.Contains(title));
            return query;
        } 
    }
}
