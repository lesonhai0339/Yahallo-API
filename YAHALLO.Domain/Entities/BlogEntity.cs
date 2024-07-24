using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.Base;

namespace YAHALLO.Domain.Entities
{
    public class BlogEntity: BaseEntity
    {
        public required string Title { get; set; }
        public string Description { get; set; } = "None";
        public string Content { get; set; } = "No Content";
        public ICollection<IFormFile>? Medias { get; set; }
        public int ViewCount { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }

        public CommonStatus Status { get; set; }
        // write list user visit this blog by date, data has been write to .txt file
        public ICollection<Metadata>? ViewCountMetadataByDate { get; set; }
        // write list user like blog  into .txt by date
        public ICollection<Metadata>? LikeMetadataByteDate { get; set; }
        // write list user dislike blog into .txt by date
        public ICollection<Metadata>? DisLikeMetadataByDate { get; set; }    
        // it look like category for manga, example : school, animal,v.v......
        public required virtual ICollection<ThreadEntity> Threads { get;set; }   

    }
}
