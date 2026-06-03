using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.GetAllPagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetNewestUpdateMangaPagination
{
    public class GetNewestUpdateMangaPaginationValidator : AbstractValidator<GetNewestUpdateMangaPaginationQuery>
    {
        public GetNewestUpdateMangaPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Size không được bỏ trống");
        }
    }
}
