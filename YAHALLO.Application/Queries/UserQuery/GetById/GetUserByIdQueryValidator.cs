using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.GetById
{
    public class GetUserByIdQueryValidator: AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator() 
        {
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
