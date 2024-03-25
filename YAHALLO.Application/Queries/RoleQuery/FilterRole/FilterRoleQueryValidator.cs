using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.RoleQuery.FilterRole
{
    public class FilterRoleQueryValidator: AbstractValidator<FilterRoleQuery>
    {
        public FilterRoleQueryValidator() { 
            RuleFor(x=> x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không thể bỏ trống");
            RuleFor(x=> x.PageSize).NotNull().NotEmpty().WithMessage("Page Size khogn6 được bỏ trống");
        }
    }
}
