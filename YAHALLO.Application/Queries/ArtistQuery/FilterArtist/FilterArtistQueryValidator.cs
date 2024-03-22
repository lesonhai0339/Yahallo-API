using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.ArtistQuery.FilterArtist
{
    public class FilterArtistQueryValidator: AbstractValidator<FilterArtistQuery>
    {
        public FilterArtistQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
        }
    }
}
