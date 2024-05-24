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
<<<<<<< HEAD
        public static ChapterDto MapToChapterDto(this ChapterEntity entity, IMapper mapper)
            => mapper.Map<ChapterDto>(entity);
        public static List<ChapterDto> MapToChapterDtoToList(this ICollection<ChapterEntity> entites, IMapper mapper)
          => entites.Select(x=> x.MapToChapterDto(mapper)).ToList();
        public static ChapterDto MapFullToChapterDto(this ChapterEntity entity, IMapper mapper)
        {
            var map= mapper.Map<ChapterDto>(entity);
            map.MangaName = entity.MangaEntity.Name ?? "";
            return map;
        }
        public static List<ChapterDto> MapFullToChapterDtoToList(this ICollection<ChapterEntity> entites, IMapper mapper)
          => entites.Select(x => x.MapFullToChapterDto(mapper)).ToList();
=======
        public static ChapterDto MapToChapterDto(this ChapterEntity entity, IMapper  mapper)
            => mapper.Map<ChapterDto>(entity);
        public static ChapterDto MapFullToChapterDto(this ChapterEntity entity, IMapper mapper)
        {
            var map= mapper.Map<ChapterDto>(entity);
            map.MangaName = entity.MangaEntity != null ? entity.MangaEntity.Name : "";
            return map;
        }
        public static List<ChapterDto> MapToChapterDtoToList(this ICollection<ChapterEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChapterDto(mapper)).ToList();
        public static List<ChapterDto> MapFullToChapterDtoToList(this ICollection<ChapterEntity> entities, IMapper mapper)
         => entities.Select(x => x.MapFullToChapterDto(mapper)).ToList();
>>>>>>> master
    }
}
