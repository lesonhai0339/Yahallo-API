using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Queries.MangaQuery.DTOs
{
    public static class MangaDtoMappingExtension
    {
        public static MangaDto MapToMangaDto(this MangaEntity entity, IMapper mapper)
            => mapper.Map<MangaDto>(entity);
        public static MangaDto MapFullToMangaDto(this MangaEntity entity, IMapper mapper)
        {
            var map = mapper.Map<MangaDto>(entity);
            map.MangaThumbnail = entity.MangaThumbnail;
            map.MangaBackground = entity.MangaBackground;   
            map.UserID = entity.IdUserCreate ?? "";
            map.Level = entity.Level;
            map.Status = entity.Status;
            map.Type = entity.Type;
            map.Countries = entity.Countries;
            map.LastestChapter = mapper.Map<ChapterDto>(entity.LastChapter);

            return map;
        }
        public static List<MangaDto> MapToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToMangaDto(mapper)).ToList();
        public static List<MangaDto> MapFullToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
           => entitiess.Select(x => x.MapFullToMangaDto(mapper)).ToList();
    }
}
