using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ArtistCommand.Restore
{
    public class RestoreArtistCommandValidator: AbstractValidator<RestoreArtistCommand> 
    {
        public RestoreArtistCommandValidator() { 
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
