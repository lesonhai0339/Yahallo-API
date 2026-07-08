using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeleted
{
    public sealed class GetAllArtistDeletedQuery : IRequest<List<AdminArtistDto>>
    {
    }
}
