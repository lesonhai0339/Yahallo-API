using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Delete
{
    public class DeleteRoleCommandValidator: AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator() { 
            RuleFor(x=> x.Id).NotNull().NotEmpty().WithMessage("Id không được bỏ trống");
        }
    }
}
