using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetProfileById
{
    public class GetProfileByIdRequestValidator: AbstractValidator<GetProfileByIdRequest>
    {
        public GetProfileByIdRequestValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("UserId cannot be null or empty!");
        }
    }
}
