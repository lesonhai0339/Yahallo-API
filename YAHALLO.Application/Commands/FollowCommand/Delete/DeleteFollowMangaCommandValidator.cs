using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.FollowCommand.Delete
{
    public  class DeleteFollowMangaCommandValidator: AbstractValidator<DeleteFollowMangaCommand>
    {
        public DeleteFollowMangaCommandValidator() 
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
