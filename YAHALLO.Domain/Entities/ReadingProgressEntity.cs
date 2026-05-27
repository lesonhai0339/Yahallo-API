//AI generated
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class ReadingProgressEntity : RelationEntity
    {
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;

        public string ChapterId { get; set; } = null!;
        public virtual ChapterEntity Chapter { get; set; } = null!;

        /// <summary>Page index the user last read (1-based).</summary>
        public int LastPage { get; set; } = 1;

        public DateTime LastReadAt { get; set; } = DateTime.Now;
    }
}
