using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Blog.GetAllPagination
{
    public class GetAllBlogPaginationQueryHandler : IRequestHandler<GetAllBlogPaginationQuery, PagedResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetAllBlogPaginationQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<PagedResult<BlogDto>> Handle(GetAllBlogPaginationQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository
                 .FindAllSelectAsync(
                    pageNo: request.PageNo,
                    pageSize: request.PageSize,
                    selector: q => q
                    .Select(x => new BlogDto
                    {
                        Id = x.Id,
                        Content = x.Content,
                        Title = x.Title,
                        Description = x.Description,
                        DisLike = x.DisLike,
                        Like = x.Like,
                        OwnerUserId = x.UserId,
                        Status = x.Status,
                        Type = x.Type,
                        ViewCount = x.ViewCount == null ? 0 : x.ViewCount.TotalCount
                    }),
                cancellationToken
                );
            return blogs.MapToPagedResult(x => x);
        }
    }
}
