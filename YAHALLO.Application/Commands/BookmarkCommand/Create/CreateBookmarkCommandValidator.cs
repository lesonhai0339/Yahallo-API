//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Create
{
    public class CreateBookmarkCommandValidator : AbstractValidator<CreateBookmarkCommand>
    {
        public CreateBookmarkCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tên dấu trang không được bỏ trống");

            // Dấu trang không gắn vào đâu cả thì không có ý nghĩa gì.
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.MangaId)
                        || !string.IsNullOrEmpty(x.ChapterId)
                        || !string.IsNullOrEmpty(x.BlogId))
                .WithMessage("Phải có ít nhất một trong MangaId, ChapterId hoặc BlogId");
        }
    }
}
