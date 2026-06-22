using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.ResponseTypes
{
    public class LoginResponse
    {
        public string? Id { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? AvatarUri { get; set; } 
        public string? Name { get; set; }
        public List<string>? Roles { get; set; }
        public UserLevel? Level { get; set; }
    }
}
