using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BlogCommand.Restore
{
    public class RestoreBlogCommandValidator: AbstractValidator<RestoreBlogCommand> 
    {
        public RestoreBlogCommandValidator() 
        {
            RuleFor(x=> x.BlogId).NotEmpty().NotNull().WithMessage("Blog Id does not empty");
        }
    }
}
