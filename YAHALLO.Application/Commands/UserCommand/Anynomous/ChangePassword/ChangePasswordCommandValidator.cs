using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.ChangePassword
{
    public class ChangePasswordCommandValidator: AbstractValidator<ChangePasswordCommand>   
    {
        public ChangePasswordCommandValidator() {
            RuleFor(x => x.OldPassword).NotEmpty().NotNull().WithMessage("Old Password không được để trống");
            RuleFor(x => x.NewPassword).NotEmpty().NotNull().WithMessage("New Password không được để trống");
        }
    }
}
