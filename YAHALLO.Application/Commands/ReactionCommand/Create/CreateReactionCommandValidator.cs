using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    public class CreateReactionCommandValidator: AbstractValidator<CreateReactionCommand>
    {
        public CreateReactionCommandValidator() 
        {
        
        } 
    }
}
