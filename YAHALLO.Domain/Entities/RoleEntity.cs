using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class RoleEntity: BaseEntity
    {
        public int RoleCode { get;set; }
        public string RoleName { get; set; } = null!;
        public string? RoleDescription { get;set;}
        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; } = null!;
    }
}
