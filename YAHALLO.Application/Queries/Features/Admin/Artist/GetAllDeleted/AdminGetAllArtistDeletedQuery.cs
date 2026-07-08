using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeleted
{
    public sealed class AdminGetAllArtistDeletedQuery : IRequest<List<AdminArtistDto>>
    {
    }
}
