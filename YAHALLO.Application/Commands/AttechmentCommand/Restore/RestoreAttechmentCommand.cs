using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.AttechmentCommand.Restore
{
    public class RestoreAttechmentCommand : IRequest<ResponseResult<string>>
    {
        public string Id {  get; set; } 
        public RestoreAttechmentCommand(string id)
        {
            Id = id;
        }   
    }
}
