using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetByName
{
    public class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
    {
        public GetUserByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Tên thành viên không được bỏ trống");
        }
    }
}
