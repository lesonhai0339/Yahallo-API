using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetImage
{
    public class GetImageValidator : AbstractValidator<GetImageQuery>
    {
        public GetImageValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("MangaId không được bỏ trống");
            RuleFor(x => x.ChapterId).NotNull().NotEmpty().WithMessage("ChapterId không được bỏ trống");

        }
    }
}
