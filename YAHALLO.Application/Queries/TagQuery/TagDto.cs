//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.TagQuery
{
    public class TagDto : IMapFrom<TagEntity>
    {
        public required string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TagEntity, TagDto>();
        }
    }
}
