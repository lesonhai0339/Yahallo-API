using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Delete
{
    public class DeleteAuthorCommand: IRequest<string>
    {
        public DeleteAuthorCommand(string id)
        {
            Id = id;
        }
        public string Id { get;set; }
    }
}
