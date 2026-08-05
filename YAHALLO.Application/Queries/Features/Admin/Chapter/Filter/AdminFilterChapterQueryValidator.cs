using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.Filter
{
    public sealed class AdminFilterChapterQueryValidator: AbstractValidator<AdminFilterChapterQuery>
    {
        public AdminFilterChapterQueryValidator() 
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("Manga Id không được bỏ trống");
        }
    }
}
