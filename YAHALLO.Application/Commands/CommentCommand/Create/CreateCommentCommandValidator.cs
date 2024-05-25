using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommandValidator: AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator() 
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("MangaId không được bỏ trống");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId không được bỏ trống");
            RuleFor(x => x.Type).NotNull().NotEmpty().WithMessage("MangaType không được bỏ trống");
            RuleFor(x => x.Data).NotNull().NotEmpty().WithMessage("Message không được bỏ trống");
        }  
    }
}
