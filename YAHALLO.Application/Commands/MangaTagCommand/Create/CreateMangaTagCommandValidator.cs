//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.MangaTagCommand.Create
{
    public class CreateMangaTagCommandValidator : AbstractValidator<CreateMangaTagCommand>
    {
        public CreateMangaTagCommandValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("MangaId không được để trống");
            RuleFor(x => x.TagId).NotNull().NotEmpty().WithMessage("TagId không được để trống");
        }
    }
}
