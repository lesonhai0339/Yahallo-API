using FluentValidation;

namespace YAHALLO.Application.Queries.MangaQuery.GetCatalog
{
    public class GetMangaCatalogQueryValidator : AbstractValidator<GetMangaCatalogQuery>
    {
        public GetMangaCatalogQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        }
    }
}

