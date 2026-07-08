using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Application.Queries.Features.Public.Blog
{
    public class BlogDto : IMapFrom<BlogEntity>
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public string? Content { get; set; } 
        public int Like { get; set; }
        public int DisLike { get; set; }
        public CommonStatus Status { get; set; }
        public BlogEnumType Type { get; set; }
        public long? ViewCount { get; set; }
        public string OwnerUserId { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogEntity, BlogDto>();   
        }
    }
}
