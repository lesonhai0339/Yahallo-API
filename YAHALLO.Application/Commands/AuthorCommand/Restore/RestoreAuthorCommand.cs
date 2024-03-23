using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Restore
{
    public class RestoreAuthorCommand: IRequest<string>
    {
        public string Id { get;set; }
        public RestoreAuthorCommand(string id)
        {
            Id = id;
        }
    }
}
