using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Domain.Entities.Reference
{
    public class ThreadOfBlogEntity: RelationEntity
    {
        public required string BlogId { get; set; }
        public required virtual BlogEntity Blog { get; set; }
        public required string ThreadId { get; set; }
        public required virtual ThreadEntity Thread { get; set; }
    }
}
