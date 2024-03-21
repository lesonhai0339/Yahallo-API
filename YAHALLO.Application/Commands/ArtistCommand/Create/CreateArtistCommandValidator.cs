using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ArtistCommand.Create
{
    public class CreateArtistCommandValidator: AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tên tác giả không được bỏ trống");
            RuleFor(x => x.Depscription)
                .NotNull().NotEmpty().WithMessage("Giới thiệu không được bỏ trống");
            RuleFor(x => x.Birth).NotNull().NotEmpty();
            RuleFor(x => x.Birth).NotEmpty().NotNull();
            RuleFor(x=> x.LifeStatus).NotNull().NotEmpty();
        }
    }
}
