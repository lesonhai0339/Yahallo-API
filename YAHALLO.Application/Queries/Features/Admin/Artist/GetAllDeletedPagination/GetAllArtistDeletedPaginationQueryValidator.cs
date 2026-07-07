using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeletedPagination
{
    public sealed class GetAllArtistDeletedPaginationQueryValidator: AbstractValidator<GetAllArtistDeletedPaginationQuery>
    {
        public GetAllArtistDeletedPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize).NotNull().NotEmpty().WithMessage("Page Number không được bỏ trống");
        }
    }
}
