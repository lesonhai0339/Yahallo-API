using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Update
{
    public class UpdateUserSettingsCommandValidator: AbstractValidator<UpdateUserSettingsCommand>
    {
        public UpdateUserSettingsCommandValidator() { } 
    }
}
