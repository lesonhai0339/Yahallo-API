//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Update
{
    public class UpdateBookmarkCommandValidator : AbstractValidator<UpdateBookmarkCommand>
    {
        public UpdateBookmarkCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id không được bỏ trống");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tên dấu trang không được bỏ trống");
        }
    }
}
