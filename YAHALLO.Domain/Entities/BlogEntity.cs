using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Domain.Entities
{
    public class BlogEntity: BaseEntity
    {
        public BlogEntity() { }
        public BlogEntity(string? parentId, string title, string description, string content, int like, int disLike, CommonStatus status, BlogEnumType type, CountingEntitity? viewCount, ICollection<ThreadOfBlogEntity>? threadOfBlogEntities, ICollection<ReactionEntity>? reactions, ICollection<CommentEntity>? comments, ICollection<AttechmentEntity>? attechments)
        {
            ParentId = parentId;
            Title = title;
            Description = description;
            Content = content;
            Like = like;
            DisLike = disLike;
            Status = status;
            Type = type;
            ViewCount = viewCount;
            ThreadOfBlogEntities = threadOfBlogEntities;
            Reactions = reactions;
            Comments = comments;
            Attechments = attechments;
        }

        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } = "None";
        public string? Content { get; set; } = "No Content";
        public int Like { get; set; } = 0;
        public int DisLike { get; set; } = 0;

        public CommonStatus Status { get; set; } = CommonStatus.Active;
        public BlogEnumType Type { get; set; }  = BlogEnumType.None;

        public virtual CountingEntitity? ViewCount { get; set; } 

        public virtual ICollection<ThreadOfBlogEntity>? ThreadOfBlogEntities { get;set; }   
        public virtual ICollection<ReactionEntity>? Reactions { get;set; }     
        public virtual ICollection<CommentEntity>? Comments { get; set; }
        public virtual ICollection<AttechmentEntity>?  Attechments { get; set; }
    }
}
