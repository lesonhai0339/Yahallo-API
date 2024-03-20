using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Delete
{
    public class DeleteUserCommandvalidator: AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandvalidator() { 
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được đeể trống");
        }
    }
}
