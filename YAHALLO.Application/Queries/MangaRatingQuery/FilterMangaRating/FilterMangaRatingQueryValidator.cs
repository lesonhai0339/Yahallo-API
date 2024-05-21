using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterMangaRatingQueryValidator: AbstractValidator<FilterMangaRatingQuery>
    {
        public FilterMangaRatingQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("PageNumber không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("PageSize không được bỏ trống");
        }
    }
}
