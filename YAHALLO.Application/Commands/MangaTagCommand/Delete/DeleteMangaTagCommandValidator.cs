//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.MangaTagCommand.Delete
{
    public class DeleteMangaTagCommandValidator : AbstractValidator<DeleteMangaTagCommand>
    {
        public DeleteMangaTagCommandValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty();
            RuleFor(x => x.TagId).NotNull().NotEmpty();
        }
    }
}
