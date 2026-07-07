using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Blog
{
    public class AdminBlogDto: IMapFrom<BlogEntity>
    {
        public string Id { get; set; } = null!;
        public string? ParentId { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public int Like { get; set; }
        public int DisLike { get; set; } 

        public CommonStatus Status { get; set; } = CommonStatus.Active;
        public BlogEnumType Type { get; set; } = BlogEnumType.None;
        public long Views { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogEntity, AdminBlogDto>();    
        }
    }
}
