using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.BlogQuery.FilterBlog
{
    public class FilterBlogQueryValidator: AbstractValidator<FilterBlogQuery>
    {
        public FilterBlogQueryValidator() 
        {
            RuleFor(x=> x.PageNumber).NotEmpty().NotNull().WithMessage("Missing PageNumber");
            RuleFor(x => x.PageSize).NotEmpty().NotNull().WithMessage("Missing PageSize");
        }   
    }
}
