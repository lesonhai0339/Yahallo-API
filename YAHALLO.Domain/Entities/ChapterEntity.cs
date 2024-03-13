using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class ChapterEntity:BaseEntity
    {
        public string? Title { get; set; }
        public int Index { get;set; }

        public string MangaId { get; set; } = null!;
        public virtual MangaEntity MangaEntity { get; set; } = null!;
        
        public virtual ICollection<ImageEntity>? ImagesEntities { get; set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
    }
}
