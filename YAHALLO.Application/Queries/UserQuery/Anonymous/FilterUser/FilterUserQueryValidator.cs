using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser
{
    public class FilterUserQueryValidator : AbstractValidator<FilterUserQuery>
    {
        public FilterUserQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().NotNull().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotEmpty().NotNull().WithMessage("Page Size không được bỏ trống");
        }
    }
}
