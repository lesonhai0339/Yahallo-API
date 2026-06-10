using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.GetHomepage
{
    internal class GetHomepageRequestValidator: AbstractValidator<GetHomepageRequest>
    {
        public GetHomepageRequestValidator() { }    
    }
}
