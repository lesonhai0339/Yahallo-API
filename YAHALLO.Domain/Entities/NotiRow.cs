using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Domain.Entities
{
    public class NotifRow
    {
        public string Id { get; set; } = string.Empty;
        public NotificationType Kind { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Seen { get; set; }
        public string? MangaId, ChapterId, BlogId, RootCommentId, CommentId, TargetId, Message, Name, ImageUrl;
        public MentionFrom MentionFrom { get; set; }
    }
}
