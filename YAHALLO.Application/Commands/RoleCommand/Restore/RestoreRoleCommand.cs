using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Restore
{
    public class RestoreRoleCommand: IRequest<string>
    {
        public string Id { get;set; }
        public RestoreRoleCommand(string id)
        {
            Id = id;
        }
    }
}
