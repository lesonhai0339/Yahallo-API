using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetImage
{
    public class GetImageValidator : AbstractValidator<GetImageQuery>
    {
        public GetImageValidator()
        {
            RuleFor(x => x.ChapterId).NotNull().NotEmpty().WithMessage("ChapterId Size không được bỏ trống");
        }
    }
}
