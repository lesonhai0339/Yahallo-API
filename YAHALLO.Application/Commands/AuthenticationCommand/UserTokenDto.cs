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
        public string? RefreshTokenExpired { get; set; }
        public string? AccessToken { get; set; }    
        public string? RefreshToken { get; set; }

        public string Id { get; set; } = string.Empty;  
        public string? DisplayName { get; set; } = string.Empty;     
        public string? Avatar { get; set; } = string.Empty;
        public UserLevel Level { get;set; }
    }
}
