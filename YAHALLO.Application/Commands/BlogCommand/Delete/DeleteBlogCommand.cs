using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.BlogCommand.Delete
{
    public class DeleteBlogCommand: IRequest<ResponseResult<string>>
    {
        public string BlogId { get; set; }
        public DeleteBlogCommand(string blogId)
        {
            BlogId = blogId;
        }   
    }
}
