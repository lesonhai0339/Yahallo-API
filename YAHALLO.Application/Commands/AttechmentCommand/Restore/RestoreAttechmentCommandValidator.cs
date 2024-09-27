using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AttechmentCommand.Restore
{
    public class RestoreAttechmentCommandValidator: AbstractValidator<RestoreAttechmentCommand> 
    {
        public RestoreAttechmentCommandValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Missing Id");
        }
    }
}
