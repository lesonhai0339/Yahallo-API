using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Delete
{
    public class DeleteMangaSeasonCommandValidator: AbstractValidator<DeleteMangaSeasonCommand> 
    {
        public DeleteMangaSeasonCommandValidator() { 
            RuleFor(x=> x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
