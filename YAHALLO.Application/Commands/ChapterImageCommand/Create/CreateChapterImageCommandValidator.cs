using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ChapterImageCommand.Create
{
    public class CreateChapterImageCommandValidator: AbstractValidator<CreateChapterImageCommand>
    {
        public CreateChapterImageCommandValidator() {
            RuleFor(x => x.ChapterId).NotNull().NotEmpty().WithMessage("Chapter Id cannot be null or empty");
            RuleFor(x => x).Must(i => i.FileUploadInfo.Any()).WithMessage("File Info cannot be null");
        }
    }
}
