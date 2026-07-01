using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class UserTokenEntity: BaseEntity
    {
        public string? IpAddress { get; set; }  
        public string? UserAgent { get; set; }  
        public string? DeviceName { get; set; }
        public DateTime LastUseDate { get; set; }
        public string? LoginLocation { get; set; }   
        public string RefreshToken { get; set; } = null!;
        public bool IsRevoked { get; set; } = false;

        public DateTime ExpiredRefreshToken { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = null!;
        public virtual UserEntity? UserEntity { get; set; }

    }
}
