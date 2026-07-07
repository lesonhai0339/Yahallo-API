using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.GetAllDeletedPagination
{
    public class GetAllBlogDeletedPaginationQueryHandler : IRequestHandler<GetAllBlogDeletedPaginationQuery, PagedResult<AdminBlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogDeletedPaginationQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<AdminBlogDto>> Handle(GetAllBlogDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository
                 .FindAllSelectAsync(
                    pageNo: request.PageNumber,
                    pageSize: request.PageSize, 
                      selector:  x => x
                         .Where(a => !string.IsNullOrWhiteSpace(a.IdUserDelete) && a.DeleteDate.HasValue)
                         .Select(t => new AdminBlogDto
                         {
                             Id = t.Id,
                             Content = t.Content,
                             Description = t.Description,
                             DisLike = t.DisLike,
                             Like = t.Like,
                             ParentId = t.ParentId,
                             Status = t.Status,
                             Title = t.Title,
                             Type = t.Type,
                             Views = t.ViewCount == null ? 0 : t.ViewCount.TotalCount
                         }),
                    cancellation: cancellationToken,
                    ignoreQueryFilters: true);

            return blogs.MapToPagedResult(x => x);
        }
    }
}
