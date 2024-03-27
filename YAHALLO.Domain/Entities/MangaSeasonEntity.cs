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
            MangaEntities = new List<MangaEntity>();
        }
        public virtual ICollection<MangaEntity> MangaEntities { get; set; } = null!;
    }
}
