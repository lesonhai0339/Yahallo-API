using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken
{
    public class CheckExpiredTokenCommandValidator: AbstractValidator<CheckExpiredTokenCommand>
    {
        public CheckExpiredTokenCommandValidator() 
        {
            RuleFor(x => x.Refeshtoken)
                .NotNull()
                .NotEmpty()
                .WithMessage("Refesh token không thể bỏ trống");
        }
    }
}
