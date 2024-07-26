using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    public class MetadataEntity : BaseEntity
    {
        public required string ParentId { get; set; }
        public virtual object Parent { get; set; } = null!;
        public string? ViewMetadata { get; set; }
        public string? LikeMetadata { get; set; }
        public string? DislikeMetadata { get; set; }
    }
}
