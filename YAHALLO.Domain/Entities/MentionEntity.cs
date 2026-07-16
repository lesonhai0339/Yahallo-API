using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MentionEntity: BaseEntity
    {
        public string UserId { get; set; } = string.Empty;

        public string RootCommentId { get; set; } = null!;
        public string? CommentId { get; set; }
        public bool Seen { get; set; } = false;
        public MentionFrom MentionFrom { get; set; } = MentionFrom.None;

        public string? MangaId { get; set;  }
        public string? ChapterId { get; set;  }
        public string? BlogId { get; set; } 



        public UserEntity? User { get; set; }
    }
    public enum MentionFrom
    {
        None,
        MangaComment,
        ChapterComment,
        BlogComment,    
    }
}
