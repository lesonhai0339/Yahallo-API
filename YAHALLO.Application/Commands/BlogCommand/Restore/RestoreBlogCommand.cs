using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.BlogCommand.Restore
{
    public class RestoreBlogCommand: IRequest<ResponseResult<string>>   
    {
        public string BlogId { get; set; }  
        public RestoreBlogCommand(string blogId)
        {
            BlogId = blogId;    
        }
    }
}
