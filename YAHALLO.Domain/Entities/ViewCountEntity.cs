using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class ViewCountEntity: BaseEntity
    {
        public long DayCount { get; set; } 
        public long MonthCount { get; set; }
        public long YearCount { get; set; }
        public long TotalCount { get; set; }    
        public DateTime LastDateModify { get; set; }
        public DateTime LastMonthModify { get; set; }
        public DateTime LastYearModify { get; set; }

        public string? MangaId { get; set; }
        public virtual MangaEntity? Manga { get; set; }
        public string? ChapterId { get; set; }   
        public virtual ChapterEntity? Chapter { get; set; }  

        public string? CommentId { get; set; }  
        public virtual CommentEntity? Comment { get; set; } 

        public string? BlogId { get; set; } 
        public virtual BlogEntity? Blog { get; set; }   

        public void AddView(DateTime now, int count = 1)
        {
            if(now.Date != LastDateModify.Date)
            {
                DayCount = 0;
                LastDateModify = now;
            }

            if (now.Year != LastYearModify.Year || now.Month != LastMonthModify.Month)
            {
                MonthCount = 0;
                LastYearModify = now;
            }

            if (now.Year != LastYearModify.Year)
            {
                YearCount = 0;
                LastYearModify = now;
            }
            DayCount++;
            MonthCount++;
            YearCount++;
            TotalCount++;
        }
    }
}
