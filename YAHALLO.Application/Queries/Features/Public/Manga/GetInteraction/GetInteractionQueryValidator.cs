using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetInteraction
{
    public class GetInteractionQueryValidator: AbstractValidator<GetInteractionQuery>
    {
        public GetInteractionQueryValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("Manga id không được bỏ trống");
        }
    }
}
