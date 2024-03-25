using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.RoleCommand.Update
{
    public class UpdateRoleCommandValidator: AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
