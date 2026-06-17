using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class UnTrustEmailEntity: BaseEntity
    {
        public string Email { get; set; } = null!;
        public string? Reason { get; set;  }
        public string? Source { get; set;  }
        public bool IsActive { get; set; } = true;
    }
}
