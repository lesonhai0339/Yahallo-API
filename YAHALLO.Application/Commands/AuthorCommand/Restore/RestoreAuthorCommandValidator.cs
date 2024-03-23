using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Restore
{
    public class RestoreAuthorCommandValidator: AbstractValidator<RestoreAuthorCommand>
    {
        public RestoreAuthorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().NotEmpty().WithMessage("Id không được để trống");
        }
    }
}
