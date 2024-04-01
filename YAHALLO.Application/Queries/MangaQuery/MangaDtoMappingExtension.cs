using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public static class MangaDtoMappingExtension
    {
        public static MangaDto MapToMangaDto(this MangaEntity entity, IMapper mapper)
            => mapper.Map<MangaDto>(entity);
        public static MangaDto MapFullToMangaDto(this MangaEntity entity, IMapper mapper)
        {
            var map = mapper.Map<MangaDto>(entity);
            map.Thumbnail = entity.Thumbnail!.BaseUrl ?? entity.Thumbnail.CloudUrl;
            map.UserID = entity.UserEntity.Id ?? "";
            map.Level = entity.Level.GetDescription();
            map.Status = entity.Status.GetDescription();
            map.Type = entity.Type.GetDescription();
            map.Countries = entity.Countries.GetDescription();  
            return map;
        }
        public static List<MangaDto> MapToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToMangaDto(mapper)).ToList();
        public static List<MangaDto> MapFullToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
           => entitiess.Select(x => x.MapFullToMangaDto(mapper)).ToList();
    }
}
