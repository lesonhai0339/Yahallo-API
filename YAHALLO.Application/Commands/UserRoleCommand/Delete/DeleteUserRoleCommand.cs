using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserRoleCommand.Delete
{
    public class DeleteUserRoleCommand: IRequest<string>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public DeleteUserRoleCommand(
            string userid,
            string roleid)
        {
            UserId = userid;
            RoleId = roleid;
        }
    }
}
