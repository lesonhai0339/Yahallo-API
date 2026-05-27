//AI generated
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class MangaTagEntity : RelationEntity
    {
        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;

        public string TagId { get; set; } = null!;
        public virtual TagEntity Tag { get; set; } = null!;
    }
}
