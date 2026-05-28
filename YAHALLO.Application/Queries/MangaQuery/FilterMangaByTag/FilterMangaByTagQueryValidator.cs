using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.FilterManga;

namespace YAHALLO.Application.Queries.MangaQuery.FilterMangaByTag
{
    internal class FilterMangaByTagQueryValidator: AbstractValidator<FilterMangaByTagQuery>
    {
        public FilterMangaByTagQueryValidator()
        {

            RuleFor(x => x.PageNumber)
              .NotNull()
              .NotEmpty()
              .GreaterThan(0)
              .WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Page Size không được bỏ trống");
        }
    }
}
