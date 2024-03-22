using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ArtistQuery.GetAllDeleted
{
    public class GetAllArtistDeletedQueryHandler : IRequestHandler<GetAllArtistDeletedQuery, List<ArtistDto>>
    {
        private readonly IArtistRepository _artistReepository;
        private readonly IMapper _mapper;
        public GetAllArtistDeletedQueryHandler(IArtistRepository artistReepository, IMapper mapper)
        {
            _artistReepository = artistReepository;
            _mapper = mapper;
        }
        public async Task<List<ArtistDto>> Handle(GetAllArtistDeletedQuery request, CancellationToken cancellationToken)
        {
            var listArtists = await _artistReepository
                           .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (!listArtists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ họa sĩ nào");
            }
            return listArtists.MapToArtistDtoToList(_mapper);
        }
    }
}
