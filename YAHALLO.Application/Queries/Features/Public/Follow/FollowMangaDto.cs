using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Follow
{
    public class FollowMangaDto : IMapFrom<FollowEntity>
    {
        public required string UserId { get; set; }
        public required string MangaId { get; set; }
        public string? UserName { get;set; }
        public string? MangaName { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public DateTime? LastUpdate { get;set; }
        public static FollowMangaDto Createmap(
            string userid,
            string mangaid,
            string? username,
            string? manganame)
        {
            return new FollowMangaDto
            {
                UserId = userid,
                MangaId = mangaid,
                UserName = username,
                MangaName = manganame,
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FollowEntity, FollowMangaDto>();
        }
    }
}
