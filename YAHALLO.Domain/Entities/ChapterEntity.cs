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
        public string? Title { get; set; }
        public int Index { get;set; }

        public string? MangaId { get; set; }
        public virtual MangaEntity? MangaEntity { get; set; }
        public virtual ViewCountEntity? ViewCount { get;set; }  
        
        public virtual ICollection<ImageEntity>? ImagesEntities { get; set; } = new List<ImageEntity>();    
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; } = new List<CommentEntity>();   
        public virtual ICollection<RatingEntity> RatingEntities { get; set; } = new List<RatingEntity>();
        public virtual ICollection<ReactionEntity> Reactions { get; set; } = new List<ReactionEntity>();
        public virtual ICollection<BookmarkEntity> Bookmarks { get; set; } = new List<BookmarkEntity>();

    }
}
