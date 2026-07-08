using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeletedPagination
{
    public sealed class GetAllAuthorDeletedPaginationQueryValidator: AbstractValidator<GetAllAuthorDeletedPaginationQuery>
    {
        public GetAllAuthorDeletedPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("PageNumber không thể bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("PageSize không thể bỏ trống");
        }
    }
}
