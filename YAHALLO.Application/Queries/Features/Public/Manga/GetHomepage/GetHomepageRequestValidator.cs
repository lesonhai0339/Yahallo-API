using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetHomepage
{
    public class GetHomepageRequestValidator: AbstractValidator<GetHomepageRequest>
    {
        public GetHomepageRequestValidator() { }    
    }
}
