using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.FileUpload;
using YAHALLO.Domain.Enums.Image;

namespace YAHALLO.Domain.Entities
{
    public class ThumbnailEntity: BaseEntity
    {
        public string? ImageUrl { get; set;  }
        public string? ResizeUrl { get; set; }  
        public int ResizeWidth { get; set; }    
        public int ResizedHeight { get; set; }  
        public string? ContentType { get; set; }
        public ThumbnailType Type { get; set;  }
        public ThumbnailStatus Status { get; set;  }
        public string? UserId { get; set;  }
        public virtual UserEntity? User { get; set;  }
        public string? MangaId { get; set; }    
        public virtual MangaEntity? Manga { get; set;  }

    }
}
