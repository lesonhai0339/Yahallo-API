using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ChapterCommand.Update
{
    public class UpdateChapterCommandValidator: AbstractValidator<UpdateChapterCommand>
    {
        public UpdateChapterCommandValidator() 
        {
            RuleFor(x => x.MangaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Manga Id không được bỏ trống");
            RuleFor(x => x.ChapterId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Chapter Id không được bỏ trống");
        }
    }
}
