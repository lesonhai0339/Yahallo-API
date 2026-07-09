using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.Features.Admin.User;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Comment
{
    public class AdminCommentDto : IMapFrom<CommentEntity>
    {
        public required string Id { get; set; }
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? ChapterName { get; set; }
        public string? ParentId { get; set; }
        public string? BlogId { get; set; }
        public string? ReplyToCommentId { get; set; }
        public string? Message { get; set; }
        public DateTime? DateTime { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public bool IsDeleted { get; set; }
        public string? DisplayName { get; set; }
        public string? Avatar { get; set; }
        public int ReplyCount { get; set; }
        public AdminUserDto? UserCommentTo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? IdUserDeleted { get; internal set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommentEntity, AdminCommentDto>();
        }
    }
}
