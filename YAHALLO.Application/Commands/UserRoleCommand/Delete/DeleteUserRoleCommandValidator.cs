using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserRoleCommand.Delete
{
    public class DeleteUserRoleCommandValidator: AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không được bỏ trống");
            RuleFor(x => x.RoleId).NotNull().NotEmpty().WithMessage("RoleId không được bỏ trống");

        }
    }
}
