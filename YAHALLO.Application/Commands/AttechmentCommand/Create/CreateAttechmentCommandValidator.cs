using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AttechmentCommand.Create
{
    public class CreateAttechmentCommandValidator: AbstractValidator<CreateAttechmentCommand>   
    {
        public CreateAttechmentCommandValidator()
        {
            RuleFor(x => x).Must(CheckValid).WithMessage("Không được bỏ trống cả 2 CommentId và BlogId hoặc điền cả 2");
        }
        public bool CheckValid(CreateAttechmentCommand command)
        {
            if(command.BlogId == null && command.CommentId == null)
            {
                return false;
            }
            else if(command.BlogId != null && command.CommentId != null)
            {
                return false;
            }
            return true;
        }
    }
}
