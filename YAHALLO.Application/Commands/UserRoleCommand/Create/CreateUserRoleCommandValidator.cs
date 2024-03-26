using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Commands.UserRoleCommand.Create
{
    public class CreateUserRoleCommandValidator: AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không thể bỏ trống");
            RuleFor(x => x.RoleId).NotNull().NotEmpty().WithMessage("RoleId không thể bỏ trống");
        }
    }
}
