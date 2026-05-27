//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.ReadingProgressCommand.Upsert
{
    public class UpsertReadingProgressCommandValidator : AbstractValidator<UpsertReadingProgressCommand>
    {
        public UpsertReadingProgressCommandValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty();
            RuleFor(x => x.ChapterId).NotNull().NotEmpty();
            RuleFor(x => x.LastPage).GreaterThan(0).WithMessage("LastPage phải lớn hơn 0");
        }
    }
}
