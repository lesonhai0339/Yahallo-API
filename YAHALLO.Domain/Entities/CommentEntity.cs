using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Domain.Entities
{
    public class CommentEntity: BaseEntity
    {
        public bool CanComment { get; set; }
        public bool CanRemove { get;set; }
        public bool CanHide { get;set; }
        public bool CanLike { get;set; }
        public bool CanReply { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get;set; }
        public int DisLike { get; set; }
        public required string Message { get; set;}
        public CommentAttechment? MetaData { get; set; }
        public bool UserLike { get; set; }
        public MangaCommentType CommentType { get; set; }
        public string? ParentId { get; set; }
        public virtual CommentEntity? Parent { get; set; }
        public string UserId { get; set; } = null!;
        public virtual UserEntity? UserEntity { get; set; }=null!;
        public string? MangaId { get; set;}
        public virtual MangaEntity? MangaEntity { get; set; }
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? UserReplyId { get; set; }
        public virtual UserEntity? UserReply { get; set; } = null!;
        public virtual ICollection<CommentEntity>? entities { get; set; }
    }
}
