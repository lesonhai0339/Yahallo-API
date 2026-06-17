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
        public CommentEntity() { }  
        public CommentEntity(bool canComment, bool canRemove, bool canHide, bool canLike, bool canReply, int commentCount, int likeCount, int disLikeCount, string message, CommentType commentType, string? parentId,string userId, UserEntity? userEntity, string? mangaId, string? chapterId)
        {
            CanComment = canComment;
            CanRemove = canRemove;
            CanHide = canHide;
            CanLike = canLike;
            CanReply = canReply;
            CommentCount = commentCount;
            LikeCount = likeCount;
            DisLikeCount = disLikeCount;
            Message = message;
            CommentType = commentType;
            ParentId = parentId;
            UserId = userId;
            UserEntity = userEntity;
            MangaId = mangaId;
            ChapterId = chapterId;
        }

        public bool CanComment { get; set; }
        public bool CanRemove { get;set; }
        public bool CanHide { get;set; }
        public bool CanLike { get;set; }
        public bool CanReply { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get;set; }
        public int DisLikeCount { get; set; }
        public string? Message { get; set;}
        public CommentType CommentType { get; set; }

        public virtual ViewCountEntity? ViewCount { get; set; }

        public string? UserId { get; set; }
        public virtual UserEntity? UserEntity { get; set; }
        public string? MangaId { get; set;}
        public virtual MangaEntity? MangaEntity { get; set; }
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? BlogId { get; set; }
        public virtual BlogEntity? BlogEntity { get; set; }

        public string? ParentId { get; set; }
        public virtual CommentEntity? Parent { get; set; }

        public string? ReplyToCommentId { get; set; }   
        public virtual CommentEntity? ReplyComment { get; set; }    

        public string? CommentToUserId { get; set; }
        public virtual UserEntity? CommentToUser { get; set; }


        public virtual ICollection<CommentEntity>? Comments { get; set; } = new List<CommentEntity>();
        public virtual ICollection<AttachmentEntity>? Attechments { get; set; }     = new List<AttachmentEntity>();  
    }
}
