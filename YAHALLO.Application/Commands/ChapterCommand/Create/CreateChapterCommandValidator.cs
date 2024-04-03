using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ChapterCommand.Create
{
    public class CreateChapterCommandValidator: AbstractValidator<CreateChapterCommand> 
    {
        public CreateChapterCommandValidator() {
            RuleFor(x => x.Index)
                .NotNull()
                .NotEmpty()
                .WithMessage("Index không thể bỏ trống");
            RuleFor(x => x.MangaId)
               .NotNull()
               .NotEmpty()
               .WithMessage("MangaId không thể bỏ trống");
        }
    }
}
