using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Delete
{
    public class DeleteUserCommand: IRequest<string>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; } 
    }
}
