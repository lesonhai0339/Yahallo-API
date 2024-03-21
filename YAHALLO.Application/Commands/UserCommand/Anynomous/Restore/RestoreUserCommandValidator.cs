using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Restore
{
    public class RestoreUserCommandValidator : AbstractValidator<RestoreUserCommand>
    {
        public RestoreUserCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id không được để trống");
        }
    }
}
