using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BlogCommand.Create
{
    public class CreateBlogCommandValidator: AbstractValidator<CreateBlogCommand>   
    {
        public CreateBlogCommandValidator() 
        {
            RuleFor(x=> x.ThreadIds).NotEmpty().NotNull().WithMessage("Thread Ids does not empty");
        } 
    }
}
