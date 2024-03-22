using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.ComfirmEmail
{
    public class ConfirmEmailCommand : IRequest<string>
    {
        public ConfirmEmailCommand() { }
        public ConfirmEmailCommand(string token, string userid)
        {
            Token = token;
            UserId = userid;
        }
        public string? Token { get; set; }
        public string? UserId { get; set; }
    }
}
