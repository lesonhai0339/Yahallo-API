using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaGroupEntity: BaseEntity
    {
        public string? Name { get; set; } 
        public string? Description { get; set; } = null;
        public virtual ICollection<MangaEntity> MangaEntities { get; set; } = new List<MangaEntity>();
    }
}
