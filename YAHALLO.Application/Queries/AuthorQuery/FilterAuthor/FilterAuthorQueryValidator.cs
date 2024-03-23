using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.AuthorQuery.FilterAuthor
{
    public class FilterAuthorQueryValidator: AbstractValidator<FilterAuthorQuery>   
    {
        public FilterAuthorQueryValidator() {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("PageNumber không thể bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("PageSize không thể bỏ trống");
        }
    }
}
