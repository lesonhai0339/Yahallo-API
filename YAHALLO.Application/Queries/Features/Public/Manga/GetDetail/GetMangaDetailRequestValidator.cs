using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
