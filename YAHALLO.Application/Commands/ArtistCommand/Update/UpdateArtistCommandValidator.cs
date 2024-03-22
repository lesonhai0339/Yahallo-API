using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ArtistCommand.Update
{
    public class UpdateArtistCommandValidator: AbstractValidator<UpdateArtistCommand>
    {
        public UpdateArtistCommandValidator() { 
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
