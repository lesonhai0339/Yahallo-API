using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class BookmarkEntity:BaseEntity
    {

        public string Name { get; set; } = null!;
        public string? Descriptions { get; set;  }


        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        public string? MangaId { get; set;  }
        public virtual MangaEntity? Manga { get; set;  }

        public  string? ChapterId { get; set;  }
        public virtual ChapterEntity? Chapter { get; set;  }

        public string? BlogId { get; set; } 
        public virtual BlogEntity? Blog { get; set; }
    }
}
