using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ChapterQuery
{
    public static class ChapterDtoMappingExtension
    {
        public static ChapterDto MapToChapterDto(this ChapterEntity entity, IMapper  mapper)
            => mapper.Map<ChapterDto>(entity);
        public static ChapterDto MapFullToChapterDto(this ChapterEntity entity, IMapper mapper)
        {
            var map= mapper.Map<ChapterDto>(entity);
            map.MangaName = entity.MangaEntity != null ? entity.MangaEntity.Name : "";
            if(entity.ImagesEntities != null) 
            {
                map.Images = entity.ImagesEntities.Where(x => x.TypeImage == Domain.Enums.Base.TypeImage.Chapter && x.ChapterId != null
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue).Select(y => (y.BaseUrl) != null ? y.BaseUrl.ToString() : (y.CloudUrl?.ToString() ?? "None")).ToList();
            }
            return map;
        }
        public static List<ChapterDto> MapToChapterDtoToList(this ICollection<ChapterEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChapterDto(mapper)).ToList();
        public static List<ChapterDto> MapFullToChapterDtoToList(this ICollection<ChapterEntity> entities, IMapper mapper)
         => entities.Select(x => x.MapFullToChapterDto(mapper)).ToList();
    }
}
