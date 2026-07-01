using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Logout
{
    public class LogoutCommand: IRequest<bool>
    {
        public string SessionId { get; init; } = null!;
    }
}
