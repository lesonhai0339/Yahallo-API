using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeletedPagination
{
    public sealed class GetAllDeletedChapterPaginationQueryValidator: AbstractValidator<GetAllDeletedChapterPaginationQuery>
    {
        public GetAllDeletedChapterPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page Size không được boo3 trống");
        }
    }
}
