using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Restore
{
    public class RestoreUserCommand: IRequest<string>
    {
        public RestoreUserCommand(string id)
        {
            Id = id;     
        }
        public string Id { get;set; }
    }
}
