using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.RecommendPassword
{
    public class RecommendPasswordCommandValidator: AbstractValidator<RecommendPasswordCommand> 
    {
        public RecommendPasswordCommandValidator()
        {
            RuleFor(x => x)
                 .Must(CheckValid)
                 .WithMessage("Phải có UserName hoặc Password");
           
        }
        private bool CheckValid(RecommendPasswordCommand command)
        {
            if(command.UserName == null && command.Email == null)
            {
                return false;
            }
            return true;
        }
    }
}
