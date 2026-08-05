using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Follow
{
    public class AdminFollowDto : IMapFrom<FollowEntity>
    {
        public string UserId { get; set; } = null!;
        public string MangaId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? UserAvatar { get; set; }

        public string? MangaName { get; set; }
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FollowEntity, AdminFollowDto>();
        }
    }
}
