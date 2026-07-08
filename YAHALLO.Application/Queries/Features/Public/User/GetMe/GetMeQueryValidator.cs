using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.User.GetMe
{
    public class GetMeQueryValidator: AbstractValidator<GetMeQuery>
    {
        public GetMeQueryValidator() { }
    }
}
