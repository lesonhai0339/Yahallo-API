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
            string baseurl,
            string? cloudurl,
            TypeImage typeimage,
            string? userid,
            string? chapterid,
            string? mangaid,
            string? idusercreate,
            DateTime createdate) 
        {
            Index = index;
            BaseUrl = baseurl;
            CloudUrl = cloudurl;
            TypeImage = typeimage;
            UserId = userid;
            ChapterId = chapterid;
            MangaId= mangaid;
            IdUserCreate = idusercreate;
            CreateDate = createdate;
        }
        public int Index { get;set; }
        public string BaseUrl { get; set; }
        public string? CloudUrl { get; set; }

        public TypeImage TypeImage { get; set; }

        public string? UserId { get; set;}
        public virtual UserEntity? UserEntity { get; set; }
        public string? ChapterId { get; set; }
        public virtual ChapterEntity? ChapterEntity { get; set; }
        public string? MangaId { get; set; }
        public virtual MangaEntity? MangaEntity { get; set; }
    }
}
