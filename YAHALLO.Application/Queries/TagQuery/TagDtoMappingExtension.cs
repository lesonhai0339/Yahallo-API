//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.TagQuery
{
    public static class TagDtoMappingExtension
    {
        public static TagDto MapToTagDto(this TagEntity entity, IMapper mapper)
            => mapper.Map<TagDto>(entity);

        public static List<TagDto> MapToTagDtoList(this IEnumerable<TagEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToTagDto(mapper)).ToList();
    }
}
