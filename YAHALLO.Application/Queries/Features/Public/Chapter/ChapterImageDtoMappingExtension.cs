using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Chapter
{
    public static class ChapterImageDtoMappingExtension
    {
        public static ChapterImageDto MapToChapterImageDto(this ChapterImageEntity entity, IMapper mapper)
            => mapper.Map<ChapterImageDto>(entity);
        public static ChapterImageDto MapFullToChapterImageDto(this ChapterImageEntity entity, IMapper mapper)
        {
            var map = mapper.Map<ChapterImageDto>(entity);
            return map;
        }
        public static List<ChapterImageDto> MapToChapterImageDtoToList(this ICollection<ChapterImageEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChapterImageDto(mapper)).ToList();
        public static List<ChapterImageDto> MapFullToChapterImageDtoToList(this ICollection<ChapterImageEntity> entities, IMapper mapper)
         => entities.Select(x => x.MapFullToChapterImageDto(mapper)).ToList();
    }
}
