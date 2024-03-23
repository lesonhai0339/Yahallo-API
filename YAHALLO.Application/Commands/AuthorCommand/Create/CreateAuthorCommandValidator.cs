using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AuthorCommand.Create
{
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator() { 
            RuleFor(x=> x.Name).NotEmpty().NotNull().WithMessage("Tên tác giả không được bỏ trống");
            RuleFor(x => x.Countries).NotEmpty().NotNull().WithMessage("Quốc gia không được bỏ trống");
            RuleFor(x => x.Depscription).NotEmpty().NotNull().WithMessage("Giới thiệu không được bỏ trống");
            RuleFor(x => x.Birth).NotEmpty().NotNull().WithMessage("Ngày sinh không được bỏ trống");
            RuleFor(x => x.LifeStatus).NotEmpty().NotNull().WithMessage("Tình trạng không được bỏ trống");

        }
    }
}
