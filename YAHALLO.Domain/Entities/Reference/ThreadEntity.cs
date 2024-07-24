using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    public class ThreadEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
