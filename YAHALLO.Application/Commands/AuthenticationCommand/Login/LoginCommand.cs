using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Login
{
    public class LoginCommand: IRequest<string>
    {
        public LoginCommand(string username, string password) 
        {
            UserName= username;
            Password= password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
