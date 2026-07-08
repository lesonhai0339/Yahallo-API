using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetDetail
{
    internal class GetMangaDetailRequestValidator: AbstractValidator<GetMangaDetailRequest>
    {
        public GetMangaDetailRequestValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
