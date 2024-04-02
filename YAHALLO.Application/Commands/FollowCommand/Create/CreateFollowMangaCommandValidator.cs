using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.FollowCommand.Create
{
    public class CreateFollowMangaCommandValidator: AbstractValidator<CreateFollowMangaCommand>
    {
        public CreateFollowMangaCommandValidator() 
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
