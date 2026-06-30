using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.FileUpload;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Domain.Entities
{
    public class ChapterImageEntity: BaseEntity
    {
        public decimal Index { get;set; }
        public string Url { get; set; } 
        public string? ResizeUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ResizeWidth { get; set;  }
        public int ResizeHeight { get; set; }
        public string? ContentType { get; set;  }

        public FileUploadStatus Status { get; set; } = FileUploadStatus.Pending;
        public string ChapterId { get; set; } = null!;
        public virtual ChapterEntity? ChapterEntity { get; set; }
    }
}
