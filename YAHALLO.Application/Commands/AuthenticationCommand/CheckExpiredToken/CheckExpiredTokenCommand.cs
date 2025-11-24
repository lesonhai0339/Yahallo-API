using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.ResponseTypes;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommand: IRequest<LoginResponse>
    {
        public CheckExpiredTokenCommand(string refeshtoken)
        {
            Refeshtoken = refeshtoken;
        }
        public string Refeshtoken { get;set; }
    }
}
