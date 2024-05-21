using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.MangaRatingQuery
{
    public static class MangaRatingDtoMappingExtennsion
    {
        public static MangaRatingDto MapToMangaRatingDto(this MangaRatingEntity entity, IMapper mapper)
            => mapper.Map<MangaRatingDto>(entity);
        public static MangaRatingDto MapFullToMangaRatingDto(this MangaRatingEntity entity, IMapper mapper)
        {
            var map= mapper.Map<MangaRatingDto>(entity);
            map.MangaName = entity.Manga.Name;
            map.UserName = entity.User.DisplayName ?? (entity.User.FirstName + " " + entity.User.LastName);
            return map;
        }
        public static List<MangaRatingDto> MapFullToMangaRatingDtoToList(this ICollection<MangaRatingEntity> entities, IMapper mapper)
          => entities.Select(x => x.MapFullToMangaRatingDto(mapper)).ToList();
        public static List<MangaRatingDto> MapToMangaRatingDtoToList(this ICollection<MangaRatingEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToMangaRatingDto(mapper)).ToList();

    }
}
