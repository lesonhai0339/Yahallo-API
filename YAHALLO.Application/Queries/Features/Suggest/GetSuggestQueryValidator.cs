using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Suggest
{
    public class GetSuggestQueryValidator:AbstractValidator<GetSuggestQuery>
    {
        public GetSuggestQueryValidator() {
            RuleFor(x => x.Keyword).NotNull().NotEmpty().WithMessage("Keyword cannot be null or empty");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Suggest type out of range");
        }   
    }
}
