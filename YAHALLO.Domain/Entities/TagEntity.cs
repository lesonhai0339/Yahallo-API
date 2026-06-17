//AI generated
using System.Collections.Generic;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class TagEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<MangaTagEntity> MangaTagEntities { get; set; } = new List<MangaTagEntity>(); 
    }
}
