using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.ChangePassword
{
    public class ChangePasswordCommand: IRequest<string>
    {
        public ChangePasswordCommand() { }  
        public ChangePasswordCommand(
            string? id,
            string? email,
            string oldpassword,
            string newpassword) 
        {
            Id = id;
            Email = email;
            OldPassword = oldpassword;
            NewPassword = newpassword;
        }
        public string? Id { get; set; }  
        public string? Email { get;set; }
        public string? OldPassword { get;set; }  
        public string? NewPassword { get;set; }
    }
}
