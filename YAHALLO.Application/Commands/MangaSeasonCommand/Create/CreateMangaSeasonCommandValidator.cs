using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Create
{
    public class CreateMangaSeasonCommandValidator: AbstractValidator<CreateMangaSeasonCommand>
    {
        public CreateMangaSeasonCommandValidator()
        {
            RuleFor(x=> x.Season).NotNull().NotEmpty().WithMessage("Manga Season không được bỏ trống");
        }
    }
}
