using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Update
{
    public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id không được bỏ trống");
        }
    }
}
