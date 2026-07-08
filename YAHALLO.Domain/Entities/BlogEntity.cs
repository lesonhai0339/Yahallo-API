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
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = "None";
        public string? Content { get; set; } = "No Content";
        public int Like { get; set; } = 0;
        public int DisLike { get; set; } = 0;
        public CommonStatus Status { get; set; } = CommonStatus.Active;
        public BlogEnumType Type { get; set; }  = BlogEnumType.None;  
        public virtual ViewCountEntity? ViewCount { get; set; }
        public string UserId { get; set; } = null!;
        public virtual UserEntity? User { get; set; }
        public virtual ICollection<ThreadOfBlogEntity>? ThreadOfBlogEntities { get;set; }   = new List<ThreadOfBlogEntity>();
        public virtual ICollection<ReactionEntity>? Reactions { get;set; }     = new List<ReactionEntity>   ();
        public virtual ICollection<CommentEntity>? Comments { get; set; } = new List<CommentEntity> ();
        public virtual ICollection<AttachmentEntity>? Attechments { get; set; } = new List<AttachmentEntity>     ();
        public virtual ICollection<BookmarkEntity> Bookmarks { get; set; } = new List<BookmarkEntity>();

    }
}
