using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Views
{
    public class MangaView
    {
        public string Id { get; set; } 
        public string MangaId { get; set; }
        public string? Title { get; set; }
        public int Index { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Countries { get; set; }
        public int Season { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
