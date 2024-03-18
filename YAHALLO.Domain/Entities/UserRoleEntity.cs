using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class UserRoleEntity: RelationEntity
    {
        public string UserId { get; set; } = null!;
        public virtual UserEntity UserEntity { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public virtual RoleEntity RoleEntity { get; set; } = null!;
    }
}
