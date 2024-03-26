using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserRoleCommand.Restore
{
    public class RestoreUserRoleCommandValidator: AbstractValidator<RestoreUserRoleCommand>
    {
        public RestoreUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không được bỏ trống");
            RuleFor(x => x.RoleId).NotNull().NotEmpty().WithMessage("RoleId không được bỏ trống");
        }
    }
}
