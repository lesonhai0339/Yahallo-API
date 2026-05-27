//AI generated
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    /// <summary>Tracks unique per-user manga views to prevent duplicate view inflation.</summary>
    [Serializable]
    public class UserMangaViewEntity : RelationEntity
    {
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;

        public DateTime ViewedAt { get; set; } = DateTime.Now;
    }
}
