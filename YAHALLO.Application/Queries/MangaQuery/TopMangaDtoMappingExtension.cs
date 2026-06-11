using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public static class TopMangaDtoMappingExtension
    {
        public static TopMangaDto MapToTopMangaDto(this MangaEntity entity, IMapper mapper)
            => mapper.Map<TopMangaDto>(entity);
        public static TopMangaDto MapFullToTopMangaDto(this MangaEntity entity, IMapper mapper)
        {
            var map = mapper.Map<TopMangaDto>(entity);
            map.View = entity.ViewCount == null ? 0 : entity.ViewCount.ViewCount;
            return map;
        }
        public static List<TopMangaDto> MapToTopMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToTopMangaDto(mapper)).ToList();
        public static List<TopMangaDto> MapFullToTopMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
           => entitiess.Select(x => x.MapFullToTopMangaDto(mapper)).ToList();
    }
}
