using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Login
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator() 
        {
            RuleFor(x=> x.UserName).NotEmpty().NotNull().WithMessage("Tên tài khoản không được bỏ trống");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Mật khẩu không được bỏ trống");
        }
    }
}
