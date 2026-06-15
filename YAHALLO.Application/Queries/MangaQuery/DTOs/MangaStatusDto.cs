using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.DTOs
{
    public class MangaStatusDto
    {
        public long? TotalViews { get; set; } 
        public double? AverageRating { get; set; }
        public int? TotalFollows { get; set; }   
        public int? TotalChapters { get; set; }  
    }
}
