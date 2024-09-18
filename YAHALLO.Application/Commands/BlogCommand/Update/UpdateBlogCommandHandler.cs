using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.BlogCommand.Update
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, ResponseResult<string>>
    {
        public Task<ResponseResult<string>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
