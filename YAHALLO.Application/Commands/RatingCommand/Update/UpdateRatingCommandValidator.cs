using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Update
{
    public class UpdateRatingCommandValidator: AbstractValidator<UpdateRatingCommand> 
    {
        public UpdateRatingCommandValidator()
        {
            RuleFor(x => x.RatingId).NotNull().NotEmpty().WithMessage("RatingId không được bỏ trống");
        }
    }
}
