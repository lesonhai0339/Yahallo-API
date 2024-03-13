using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Domain.Entities
{
    public class CommentEntity: BaseEntity
    {
        public string? Data { get; set; }

        public MangaCommentType CommentType { get; set; }
        public string UserId { get; set; } = null!;
        public virtual UserEntity UserEntity { get; set; }=null!;
        public string? MangaId { get; set;}
        public virtual MangaEntity? MangaEntity { get; set; }
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? UserReplyId { get; set; }
        public virtual UserEntity UserReply { get; set; } = null!;
    }
}
