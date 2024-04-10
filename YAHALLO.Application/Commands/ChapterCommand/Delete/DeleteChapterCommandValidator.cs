using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ChapterCommand.Delete
{
    public class DeleteChapterCommandValidator: AbstractValidator<DeleteChapterCommand> 
    {
        public DeleteChapterCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().NotNull()
                .WithMessage("Id không thể bỏ trống");
        }
    }
}
