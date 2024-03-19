using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Update
{
    public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        { 
        }
    }
}
