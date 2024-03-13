using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class FollowEntity: RelationEntity
    {
        public string UserId { get; set; } =null!;
        public string MangaId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
        public virtual MangaEntity Manga { get; set; } = null!;
    }
}
