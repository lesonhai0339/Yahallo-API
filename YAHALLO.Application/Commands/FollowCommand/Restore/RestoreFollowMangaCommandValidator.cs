using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.FollowCommand.Restore
{
    public class RestoreFollowMangaCommandValidator: AbstractValidator<RestoreFollowMangaCommand>
    {
        public RestoreFollowMangaCommandValidator() 
        {
            RuleFor(x => x.MangaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Manga Id không được bỏ trống");
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("User Id không được bỏ trống");
        }
    }
}
