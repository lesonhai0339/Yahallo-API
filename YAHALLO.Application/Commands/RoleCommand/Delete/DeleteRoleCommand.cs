using MediatR;
using Org.BouncyCastle.Asn1.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Delete
{
    public class DeleteRoleCommand: IRequest<string>
    {
        public DeleteRoleCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }  
    }
}
