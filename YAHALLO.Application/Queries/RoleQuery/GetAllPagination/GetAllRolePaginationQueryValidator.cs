using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllPagination
{
    public class GetAllRolePaginationQueryValidator: AbstractValidator<GetAllRolePaginationQuery>
    {
        public GetAllRolePaginationQueryValidator()
        {
            RuleFor(x=> x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page Size không được bỏ trống");
        }
    }
}
