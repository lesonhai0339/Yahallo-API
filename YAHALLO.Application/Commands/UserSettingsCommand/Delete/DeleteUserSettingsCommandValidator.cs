using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Delete
{
    public class DeleteUserSettingsCommandValidator: AbstractValidator<DeleteUserSettingsCommand>
    {
        public DeleteUserSettingsCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be null or empty");  
        } 
    }
}
