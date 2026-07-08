using MediatR;
using YAHALLO.Application.Queries.FollowQuery;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeleted
{
    public sealed class GetAllDeletedFollowMangaQuery: IRequest<List<AdminFollowDto>>
    {
    }
}
