using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Update
{
    public class UpdateMangaRatingCommandValidator: AbstractValidator<UpdateMangaRatingCommand> 
    {
        public UpdateMangaRatingCommandValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("MangaId không được bỏ trống");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không được bỏ trống");
        }
    }
}
