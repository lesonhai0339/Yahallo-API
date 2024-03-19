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
        public ImageEntity() { }
        public ImageEntity(
            int index,
            string url,
            TypeImage typeimage,
            string? userid,
            string? chapterid,
            string? mangaid,
            string? idusercreate,
            DateTime createdate) 
        {
            Index = index;
            Url = url;
            TypeImage = typeimage;
            UserId = userid;
            ChapterId = chapterid;
            MangaId= mangaid;
            IdUserCreate = idusercreate;
            CreateDate = createdate;
        }
        public int Index { get;set; }
        public string Url { get; set; } = null!;
        //public string BaseUrl { get; set; } migration sau
        //public string CloudUrl { get; set; }

        public TypeImage TypeImage { get; set; }

        public string? UserId { get; set;}
        public virtual UserEntity? UserEntity { get; set; }
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? MangaId { get; set; }
        public virtual MangaEntity? MangaEntity { get; set; }
    }
}
