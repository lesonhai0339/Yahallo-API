using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.ComfirmEmail
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.Token).NotNull().NotEmpty().WithMessage("Token không có giá trị");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("User Id không có giá trị");
        }
    }
}
