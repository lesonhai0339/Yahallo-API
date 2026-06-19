//AI generated
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class NotificationEntity : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;

        public NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; } = NotificationStatus.Unread;

        /// <summary>Optional reference id (e.g. MangaId, ChapterId).</summary>
        public string? ReferenceId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }
    }
}
