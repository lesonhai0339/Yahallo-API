//AI generated
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    /// <summary>
    /// Log mỗi lượt xem manga để dedup (chống thổi view).
    /// 2 case định danh: user đã login (UserId) hoặc khách vãng lai (VisitorId - GUID từ client).
    /// </summary>
    [Serializable]
    public class UserMangaViewEntity : BaseEntity
    {
        // Khi user đã login.
        public string? UserId { get; set; }
        public virtual UserEntity? User { get; set; }

        // Khi khách vãng lai (GUID lưu localStorage phía client). Chỉ 1 trong 2 (UserId/VisitorId) có giá trị.
        public string? VisitorId { get; set; }

        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;

        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
    }
}
