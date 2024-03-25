using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Create
{
    public class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>   
    {
        public CreateRoleCommandValidator() {
            RuleFor(x => x.RoleCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("Role Code không thể bỏ trống");
            RuleFor(x => x.RoleName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Role name không thể bỏ trống");
            RuleFor(x => x.RoleDescription)
                .NotNull()
                .NotEmpty()
                .WithMessage("Role description không thể bỏ trống");
        }
    }
}
