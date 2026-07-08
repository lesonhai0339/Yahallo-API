using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.GetAllDeleted
{
    public sealed class AdminGetAllBlogDeletedQueryHandler : IRequestHandler<AdminGetAllBlogDeletedQuery, List<AdminBlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        public AdminGetAllBlogDeletedQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
    
        public async Task<List<AdminBlogDto>> Handle(AdminGetAllBlogDeletedQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository
                .FindAllSelectAsync(x=> x
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
                cancellationToken, 
                true);

            return blogs;
        }
    }
}
