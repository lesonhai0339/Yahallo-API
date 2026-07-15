using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Tag.GetById
{
    public class GetTagInfoByIdQueryValidator: AbstractValidator<GetTagInfoByIdQuery>
    {
        public GetTagInfoByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Tag id cannot be null or empty");
        }
    }
}
