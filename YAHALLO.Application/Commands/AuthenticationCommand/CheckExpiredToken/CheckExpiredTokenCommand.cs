using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.ResponeTypes;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommand: IRequest<LoginRespone>
    {
        public CheckExpiredTokenCommand(string refeshtoken)
        {
            Refeshtoken = refeshtoken;
        }
        public string Refeshtoken { get;set; }
    }
}
