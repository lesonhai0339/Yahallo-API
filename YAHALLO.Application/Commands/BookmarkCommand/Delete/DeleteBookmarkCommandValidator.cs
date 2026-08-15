//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Delete
{
    public class DeleteBookmarkCommandValidator : AbstractValidator<DeleteBookmarkCommand>
    {
        public DeleteBookmarkCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id không được bỏ trống");
        }
    }
}
