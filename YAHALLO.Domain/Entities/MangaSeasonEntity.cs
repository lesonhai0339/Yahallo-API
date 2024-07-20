using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaSeasonEntity: BaseEntity
    {
        public MangaSeasonEntity()
        {
            Season = 1;
            MangaEntities = new List<MangaEntity>();
        }
        public MangaSeasonEntity(double season, string? description)
        {
            Description = description ?? null;
            Season = season;
            MangaEntities = new List<MangaEntity>();
        }
        public double Season { get;set; }
        public string? Description { get;set; }
        public virtual ICollection<MangaEntity> MangaEntities { get; set; } = null!;
    }
}
