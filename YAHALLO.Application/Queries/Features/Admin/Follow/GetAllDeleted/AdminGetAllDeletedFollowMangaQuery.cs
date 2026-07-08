using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeleted
{
    public sealed class AdminGetAllDeletedFollowMangaQuery: IRequest<List<AdminFollowDto>>
    {
    }
}
