using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public static class MangaDtoMappingExtension
    {
        public static MangaDto MapToMangaDto(this MangaEntity entity, IMapper mapper)
            => mapper.Map<MangaDto>(entity);
        public static MangaDto MapFullToMangaDto(this MangaEntity entity, IMapper mapper, ChapterEntity? latestChapter = null)
        {
            var map = mapper.Map<MangaDto>(entity);
            if(entity.Thumbnail != null)
            {
                if(!string.IsNullOrEmpty(entity.Thumbnail.CloudUrl))
                    {
                    map.Thumbnail = entity.Thumbnail.CloudUrl;
                }
                else if(!string.IsNullOrEmpty(entity.Thumbnail.BaseUrl))
                {
                    map.Thumbnail = entity.Thumbnail.BaseUrl;
                }   
            }

            map.Thumbnail = entity.Thumbnail != null ? entity.Thumbnail.CloudUrl : null;    
            map.UserID = entity.IdUserCreate ?? "";
            map.Level = entity.Level.GetDescription();
            map.Status = entity.Status.GetDescription();
            map.Type = entity.Type.GetDescription();
            map.Countries = entity.Countries.GetDescription();
            if (latestChapter != null)
            {
                map.LatestChapter = latestChapter.MapFullToChapterDto(mapper);
            }
            return map;
        }
        public static List<MangaDto> MapToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToMangaDto(mapper)).ToList();
        public static List<MangaDto> MapFullToMangaDtoToList(this ICollection<MangaEntity> entitiess, IMapper mapper)
           => entitiess.Select(x => x.MapFullToMangaDto(mapper)).ToList();
    }
}
