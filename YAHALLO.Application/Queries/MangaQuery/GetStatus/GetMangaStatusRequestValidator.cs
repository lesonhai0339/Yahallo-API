using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.GetStatus
{
    internal class GetMangaStatusRequestValidator: AbstractValidator<GetMangaStatusRequest>
    {
        public GetMangaStatusRequestValidator() 
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty();   
        } 
    }
}
