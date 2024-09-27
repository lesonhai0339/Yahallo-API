using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.BlogQuery.GetAllPagination
{
    public class GetAllBlogPaginationQueryValidator: AbstractValidator<GetAllBlogPaginationQuery>
    {
        public GetAllBlogPaginationQueryValidator() 
        {
            RuleFor(x=> x.PageNumber).NotNull().NotEmpty().WithMessage("Missing Page Number");
            RuleFor(x=> x.PageSize).NotNull().NotEmpty().WithMessage("Missing Page Size");
        }
    }
}
