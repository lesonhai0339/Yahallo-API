using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain
{
    public class UserMangaDailyReadEntity: BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string MangaId { get; set; } = null!;
        public string ChapterId { get; set; } = null!;
        public DateTime Date { get; set;  } 
        public virtual UserEntity? User { get; set;  }
        public virtual MangaEntity? Manga { get; set;  }
        public virtual ChapterEntity? Chapter { get; set; }
    }
}
