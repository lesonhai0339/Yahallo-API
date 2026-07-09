using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.Filter
{
    public sealed class AdminBlogFilterQueryHandler : IRequestHandler<AdminBlogFilterQuery, PagedResult<AdminBlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        public AdminBlogFilterQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<PagedResult<AdminBlogDto>> Handle(AdminBlogFilterQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(b => new AdminBlogDto
                    {
                        Id = b.Id,
                        Description = b.Description,
                        Content = b.Content,
                        DisLike = b.DisLike,
                        Like = b.Like,
                        ParentId = b.UserId, 
                        Status = b.Status,
                        Title = b.Title,
                        Type = b.Type, 
                        Views = b.ViewCount == null? 0 : b.ViewCount.TotalCount,
                        CreateDate = b.CreateDate,
                        DeleteDate = b.DeleteDate,
                    }),
                cancellation: cancellationToken,
                ignoreQueryFilters: request.IsDeleted
                );
            return blogs.MapToPagedResult(x => x);
        }
        private IQueryable<BlogEntity> ApplyFilter(IQueryable<BlogEntity> filter, AdminBlogFilterQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) filter = filter.Where(x => x.Id == request.Id);
            if (!string.IsNullOrEmpty(request.ParentId)) filter = filter.Where(x => x.UserId == request.ParentId);

            if (request.Status != null) filter = filter.Where(x => x.Status == request.Status);

            if (request.Type != null) filter = filter.Where(x => x.Type == request.Type);

            if (request.IsDeleted)
                filter = filter.Where(x => x.DeleteDate.HasValue);

            return filter;
        }
        private IQueryable<BlogEntity> ApplySorting(IQueryable<BlogEntity> filter, AdminBlogFilterQuery request)
        {
            return request.SortBy switch
            {
                AdminFilterBlogSortBy.Like => OrderHelper.ApplyOrder(filter, x => x.Like, request.ReverseSort),
                AdminFilterBlogSortBy.DisLike => OrderHelper.ApplyOrder(filter, x => x.DisLike, request.ReverseSort),
                _ => filter.OrderBy(x => x.Id)
            };
        }
    }
}
