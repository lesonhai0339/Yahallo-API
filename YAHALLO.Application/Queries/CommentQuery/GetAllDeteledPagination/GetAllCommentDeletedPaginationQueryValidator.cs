using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllDeteledPagination
{
    public class GetAllCommentDeletedPaginationQueryValidator: AbstractValidator<GetAllCommentDeletedPaginationQuery> 
    {
        public GetAllCommentDeletedPaginationQueryValidator() 
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotEmpty().NotNull().WithMessage("Page Size không được bỏ trống");
        }
    }
}
