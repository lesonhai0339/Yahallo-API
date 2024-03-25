using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Update
{
    public class UpdateRoleCommand: IRequest<string>
    {
        public UpdateRoleCommand(
            string id,
            int? rolecode,
            string? rolename,
            string? roledescription) 
        {
            Id = id;
            RoleCode = rolecode;
            RoleDescription = roledescription;
            RoleName = rolename;
        }
        public string Id { get;set; }
        public int? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}
