using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserRoleCommand.Create
{
    public class CreateUserRoleCommand: IRequest<string>
    {
        public CreateUserRoleCommand(
            string userid,
            string roleid)
        {
            UserId = userid;
            RoleId = roleid;
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
