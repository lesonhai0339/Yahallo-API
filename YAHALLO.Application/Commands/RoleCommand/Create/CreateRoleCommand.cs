using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Create
{
    public class CreateRoleCommand: IRequest<string>
    {
        public CreateRoleCommand(
            int rolecode,
            string rolename,
            string roledescription)
        {
            RoleCode = rolecode;
            RoleName = rolename;    
            RoleDescription = roledescription;  
        }
        public int RoleCode { get; set; }
        public string RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}
