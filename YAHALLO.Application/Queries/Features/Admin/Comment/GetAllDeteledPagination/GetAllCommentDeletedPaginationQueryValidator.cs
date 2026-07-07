using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeteledPagination
{
    public sealed class GetAllCommentDeletedPaginationQueryValidator: AbstractValidator<GetAllCommentDeletedPaginationQuery> 
    {
        public GetAllCommentDeletedPaginationQueryValidator() 
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotEmpty().NotNull().WithMessage("Page Size không được bỏ trống");
        }
    }
}
