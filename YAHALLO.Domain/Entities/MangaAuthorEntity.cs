using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class MangaAuthorEntity: RelationEntity
    {
        public string MangaId { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;
        public string AuthorId { get; set; } = null!;
        public virtual AuthorEntity Author { get; set; } = null!;
    }
}
