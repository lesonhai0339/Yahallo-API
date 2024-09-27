using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.RecommendPassword
{
    public class RecommendPasswordCommand: IRequest<ResponseResult<string>>
    {
        public RecommendPasswordCommand(string? username, string? email) 
        {
            UserName = username;
            Email = email;
        }
        public string? UserName { get;set; }
        public string? Email { get; set; }
    }
}
