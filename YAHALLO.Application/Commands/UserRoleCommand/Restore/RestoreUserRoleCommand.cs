using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserRoleCommand.Restore
{
    public class RestoreUserRoleCommand: IRequest<string>
    {
        public string UserId { get; set; }  
        public string RoleId { get; set; }
        public RestoreUserRoleCommand(
            string userid,
            string roleid)
        {
            UserId = userid;
            RoleId = roleid;
        }
    }
}
