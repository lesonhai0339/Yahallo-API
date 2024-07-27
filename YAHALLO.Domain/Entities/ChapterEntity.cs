using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Domain.Entities
{
    public class ChapterEntity:BaseEntity
    {
        public ChapterEntity() 
        {
            ImagesEntities = new List<ImageEntity>();
        }
        public string? Title { get; set; }
        public int Index { get;set; }

        public string MangaId { get; set; } = null!;
        public virtual MangaEntity MangaEntity { get; set; } = null!;
        public virtual CountingEntitity? ViewCount { get;set; }  
        
        public virtual ICollection<ImageEntity>? ImagesEntities { get; set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
    }
}
