using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.BlogCommand.Update
{
    public class UpdateBlogCommand: IRequest<ResponseResult<string>>
    {
        public UpdateBlogCommand() { }
    }
}
