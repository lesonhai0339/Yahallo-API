using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.GetAllDeleted
{
    public sealed class AdminGetAllBlogDeletedQuery: IRequest<List<AdminBlogDto>>
    {
    }
}
