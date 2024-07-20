using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Restore
{
    public class RestoreMangaSeasonCommandValidator: AbstractValidator<RestoreMangaSeasonCommand>
    {
        public RestoreMangaSeasonCommandValidator() 
        {
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
