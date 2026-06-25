using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Restore
{
    public class RestoreUserSettingsCommandValidator: AbstractValidator<RestoreUserSettingsCommand>
    {
        public RestoreUserSettingsCommandValidator() {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be null or empty");  
        }
    }
}
