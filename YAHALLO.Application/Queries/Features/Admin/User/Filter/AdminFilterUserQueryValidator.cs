using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.User.Filter
{
    public sealed class AdminFilterUserQueryValidator: AbstractValidator<AdminFilterUserQuery>
    {
        public AdminFilterUserQueryValidator() {
            RuleFor(x => x.PageNumber).NotEmpty().NotNull().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotEmpty().NotNull().WithMessage("Page Size không được bỏ trống");
        }
    }
}
