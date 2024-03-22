using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ArtistQuery
{
    public static class ArtistDtoMappingExtension
    {
        public static ArtistDto MapToArtistDto(this ArtistEntity entity, IMapper mapper) =>
            mapper.Map<ArtistDto>(entity);
        public static List<ArtistDto> MapToArtistDtoToList(this IEnumerable<ArtistEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapToArtistDto(mapper)).ToList();
    }
}
