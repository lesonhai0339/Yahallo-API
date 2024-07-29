using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ReportEnums;

namespace YAHALLO.Domain.Entities
{
    public class ReportEntity: BaseEntity
    {
        public string Title { get; set; } = null!;
        public ReportEnumType Type { get; set; }    
        public string? Target { get;set; }
        public string? Description { get; set; } 
        public string? Content { get; set; }


        public virtual ICollection<AttechmentEntity>? Attechments { get; set; }

        public string IdUserReport { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}
