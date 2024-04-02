using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.FollowQuery
{
    public static class FollowMangaDtoMappingExtension
    {
        public static FollowMangaDto MapToFollowMangaDto(this FollowEntity entity, IMapper mapper)
            => mapper.Map<FollowMangaDto>(entity);
        public static FollowMangaDto MapFullToFollowMangaDto(this FollowEntity entity, IMapper mapper)
        {
            var map= mapper.Map<FollowMangaDto>(entity);
            map.UserName = entity.User.DisplayName ?? entity.User.FirstName + "" + entity.User.LastName ??"";
            map.MangaName = entity.Manga !=null ? entity.Manga.Name : "";
            return map;
        }
        public static List<FollowMangaDto> MapToFollowMangaDtoToList(this ICollection<FollowEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToFollowMangaDto(mapper)).ToList();
        public static List<FollowMangaDto> MapFullToFollowMangaDtoToList(this ICollection<FollowEntity> entities, IMapper mapper)
          => entities.Select(x => x.MapFullToFollowMangaDto(mapper)).ToList();
    }
}
