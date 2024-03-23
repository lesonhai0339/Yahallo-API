using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Delete
{
    public class DeleteAuthorCommandValidator: AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
