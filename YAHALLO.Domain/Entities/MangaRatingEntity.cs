using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaRatingEntity: BaseEntity
    {
        [Range(0, 10)]
        public int Rating { get; set; }
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;
    }
}
