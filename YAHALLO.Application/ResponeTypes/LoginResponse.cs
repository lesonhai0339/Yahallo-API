using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.ResponseTypes
{
    public class LoginResponse
    {
        public LoginResponse() { }
        public LoginResponse(
            string? id, 
            string? avatarUri,
            string? name,
            string? accessToken,
            string? refreshToken)
        { 
            Id= id;
            AvatarUri = avatarUri; 
            Name= name;
            AccessToken = accessToken;
            RefreshToken = refreshToken;  
        }
        public string? Id { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? AvatarUri { get; set; } 
        public string? Name { get; set; }
    }
}
