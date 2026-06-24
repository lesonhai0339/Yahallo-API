using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.ReadingProgressQuery.GetByUserPagination
{
    public class GetReadingProgressByUserPaginationQueryValidator: AbstractValidator<GetReadingProgressByUserPaginationQuery>
    {
        public GetReadingProgressByUserPaginationQueryValidator() 
        {
            RuleFor(x => x.PageSize).GreaterThan(0).WithErrorCode("Page size must greater than 0");
            RuleFor(x => x.PageNumber).GreaterThan(0).WithErrorCode("Page number must greater than 0");
        }
    }
}
