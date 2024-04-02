using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.FollowQuery.GetAllDeletedPagination
{
    public class GetAllDeletedFollowMangaPaginationQueryValidator: AbstractValidator<GetAllDeletedFollowMangaPaginationQuery>
    {
        public GetAllDeletedFollowMangaPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize)
                .Null().NotEmpty().WithMessage("Page Size không được bỏ trống");
        }
    }
}
