using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Domain.Entities
{
    public class ImageEntity: BaseEntity
    {
        public int Index { get;set; }
        public string? BaseUrl { get; set; } 
        public string? CloudUrl { get; set; }

        public TypeImage TypeImage { get; set; }

        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? MangaId { get; set; }
    }
}
