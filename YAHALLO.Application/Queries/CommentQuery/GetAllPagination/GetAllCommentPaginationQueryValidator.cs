using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllPagination
{
    public class GetAllCommentPaginationQueryValidator: AbstractValidator<GetAllCommentPaginationQuery>
    {
        public GetAllCommentPaginationQueryValidator() { 
            RuleFor(x=> x.PageNumber).NotEmpty().NotNull().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page size không được bỏ trống");
        }
    }
}
