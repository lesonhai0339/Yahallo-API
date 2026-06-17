using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain
{
    public class UserBlacklistEntity: BaseEntity
    {

        public string? Reason { get; set; } 
        public DateTime ExpiredAt { get; set;  }
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}
