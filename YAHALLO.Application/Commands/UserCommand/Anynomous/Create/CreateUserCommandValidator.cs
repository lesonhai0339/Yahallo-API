using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email must not be null")
                .NotEmpty().WithMessage("Email must not be empty")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name must not be empty")
                .NotNull().WithMessage("First name must not be null");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name must not be empty")
                .NotNull().WithMessage("Last name must not be null");

            RuleFor(x => x.PhoneNumber)
                .Must(x => long.TryParse(x, out _)).WithMessage("Invalid phone number");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username must not be empty")
                .NotNull().WithMessage("Username must not be null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$")
                .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character");
        }

    }
}
