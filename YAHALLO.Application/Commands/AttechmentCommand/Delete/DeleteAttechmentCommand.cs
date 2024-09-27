using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.AttechmentCommand.Delete
{
    public class DeleteAttechmentCommand: IRequest<ResponseResult<string>>
    {
        public string Id { get; set; }  
        public DeleteAttechmentCommand( string id)
        {
            Id = id;
        }
    }
}
