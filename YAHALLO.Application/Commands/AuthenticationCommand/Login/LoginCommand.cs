using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.ResponseTypes;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Login
{
    public class LoginCommand: IRequest<AuthResult>
    {
        public string UserName { get; init; }
        public string Password { get; init; }
        public string? DeviceName { get; init; } 
        public string? IpAddress { get; set; }  
        public string? UserAgent { get; set; }  

    }
    public record AuthResult(LoginResponse Info, string AccessToken, string RefreshToken);
}
