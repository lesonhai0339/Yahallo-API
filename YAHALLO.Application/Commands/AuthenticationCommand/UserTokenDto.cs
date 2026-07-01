using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.AuthenticationCommand
{
    public class UserTokenDto
    {
        public string UserId { get; set; } = null!;
        public UserLevel Level { get; set; }
        
        public List<RoleDto> Roles { get; set; }   = new List<RoleDto>();
        public string RefreshToken { get; set; } = null!;
        public DateTime Expired { get; set; }  
        public bool  IsRevoked { get; set; }
        public string? Avatar { get; internal set; }
        public string? DisplayName { get; internal set; }
    }
    public class RoleDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
