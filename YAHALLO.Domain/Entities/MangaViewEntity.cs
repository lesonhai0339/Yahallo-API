using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaViewEntity: RelationEntity
    {
        public int View {get; set;}
        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;
        public void AddView(int count)
        {
            View += count;
        }
    }
}
