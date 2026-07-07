using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaDailyAnalyticsEntity: BaseEntity
    {
        public int ViewCount { get; set;  }
        public int CommentCount { get; set; }   
        public int FollowerCount { get; set; }  
        public DateTime Date { get; set;  }
        public string MangaId { get; set; } = null!; 
        public virtual MangaEntity? Manga { get; set; } 
    }
}
