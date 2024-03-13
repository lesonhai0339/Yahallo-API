using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaAssociateNameEntity: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; }= null!;
    }
}
