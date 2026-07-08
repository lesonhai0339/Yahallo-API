using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Rating.GetAllDeleted
{
    public sealed class AdminGetAllDeletedRatingQuery: IRequest<List<AdminRatingDto>>
    {
    }
}
