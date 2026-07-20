//AI generated
using System.ComponentModel;

namespace YAHALLO.Domain.Enums.NotificationEnums
{
    public enum NotificationType
    {
        [Description("Chapter mới")]
        NewChapter = 1,

        [Description("Manga mới")]
        NewManga = 2,

        [Description("Bình luận")]
        Comment = 3,

        [Description("Hệ thống")]
        System = 4,

        [Description("Đề cập")]
        Mention = 5,    
    }

    public enum NotificationStatus
    {
        Unread = 1,
        Read = 2,
    }
}
