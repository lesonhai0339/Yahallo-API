using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Delete
{
    public class DeleteMangaRatingCommandValidator: AbstractValidator<DeleteMangaRatingCommand>
    {
        public DeleteMangaRatingCommandValidator()
        {
            RuleFor(x => x.Mangaid).NotNull().NotEmpty().WithMessage("MangaId không thể bỏ trống");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không thể bỏ trống");
        }
    }
}
