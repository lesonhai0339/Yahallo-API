using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Rating
{
    public static class RatingDtoMappingExtennsion
    {
        public static RatingDto MapToMangaRatingDto(this RatingEntity entity, IMapper mapper)
            => mapper.Map<RatingDto>(entity);
        public static RatingDto MapFullToMangaRatingDto(this RatingEntity entity, IMapper mapper)
        {
            var map= mapper.Map<RatingDto>(entity);
            return map;
        }
        public static List<RatingDto> MapFullToMangaRatingDtoToList(this ICollection<RatingEntity> entities, IMapper mapper)
          => entities.Select(x => x.MapFullToMangaRatingDto(mapper)).ToList();
        public static List<RatingDto> MapToMangaRatingDtoToList(this ICollection<RatingEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToMangaRatingDto(mapper)).ToList();

    }
}
