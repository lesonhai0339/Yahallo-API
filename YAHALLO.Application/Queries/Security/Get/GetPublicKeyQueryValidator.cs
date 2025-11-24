using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Security.Get
{
    public class GetPublicKeyQueryValidator: AbstractValidator<GetPublicKeyQuery>
    {
        public GetPublicKeyQueryValidator() { }
    }
}
