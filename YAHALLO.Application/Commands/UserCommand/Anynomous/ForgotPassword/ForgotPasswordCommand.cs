using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<string>
    {
        public ForgotPasswordCommand(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
