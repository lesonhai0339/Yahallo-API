using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeletedPagination
{
    public sealed class GetAllDeletedFollowMangaPaginationQueryValidator: AbstractValidator<GetAllDeletedFollowMangaPaginationQuery>
    {
        public GetAllDeletedFollowMangaPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize)
                .Null().NotEmpty().WithMessage("Page Size không được bỏ trống");
        }
    }
}
