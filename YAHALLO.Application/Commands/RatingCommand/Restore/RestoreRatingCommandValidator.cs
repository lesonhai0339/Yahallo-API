using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Restore
{
    public class RestoreRatingCommandValidator: AbstractValidator<RestoreRatingCommand>
    {
        public RestoreRatingCommandValidator()
        {
            RuleFor(x => x.TargetId).NotNull().NotEmpty().WithMessage("MangaId không được bỏ trống");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không được bỏ trống");
        }
    }
}
