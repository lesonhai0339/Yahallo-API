using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BlogCommand.Delete
{
    public class DeleteBlogCommandValidator: AbstractValidator<DeleteBlogCommand>   
    {
        public DeleteBlogCommandValidator() 
        {
            RuleFor(x=> x.BlogId).NotEmpty().NotNull().WithMessage("BlogId does not empty");
        }
    }
}
