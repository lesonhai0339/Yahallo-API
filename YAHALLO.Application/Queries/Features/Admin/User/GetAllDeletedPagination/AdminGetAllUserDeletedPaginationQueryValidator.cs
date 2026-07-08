using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeletedPagination
{
    public sealed class GetAllUserDeletedPaginationQueryValidator : AbstractValidator<GetAllUserDeletedPaginationQuery>
    {
        public GetAllUserDeletedPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page Size không được bỏ trống");
        }
    }
}
