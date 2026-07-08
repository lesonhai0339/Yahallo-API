using AutoMapper;
using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAll
{
    public class GetAllArtistQueryhandler : IRequestHandler<GetAllArtistQuery, List<ArtistDto>>
    {
        private readonly IArtistRepository _artistReepository;
        private readonly IMapper _mapper;
        public GetAllArtistQueryhandler(IArtistRepository artistReepository, IMapper mapper)
        {
            _artistReepository = artistReepository;
            _mapper = mapper;
        }
        public async Task<List<ArtistDto>> Handle(GetAllArtistQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistReepository .FindAllAsync(cancellationToken);
            return artists.MapToArtistDtoToList(_mapper);
        }
    }
}
