using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Domain.Entities
{
    public class ThreadEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public virtual ICollection<ThreadOfBlogEntity>? ThreadOfBlogEntities { get; set; }
    }
}
