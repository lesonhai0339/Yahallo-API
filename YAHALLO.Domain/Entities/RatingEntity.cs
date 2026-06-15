using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Domain.Entities
{
    public class RatingEntity: BaseEntity
    {
        public double Rating { get; set; }  
        public RatingEnum RatingTo { get; set; }
        public string UserId { get; set; }   = string.Empty;
        public virtual UserEntity? User { get; set; } 

        public string? ToMangaId { get; set; }    
        public virtual MangaEntity? ToManga { get; set; } = null;
        public string? ToChapterId { get; set; }
        public virtual ChapterEntity? ToChapter { get; set; } 
        public string? ToUserId { get; set; } 
        public virtual UserEntity? ToUser { get; set; }       
    }
}
