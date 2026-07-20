using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.Mention.Update
{
    public class UpdateMentionCommandValidator: AbstractValidator<UpdateMentionCommand>
    {
        public UpdateMentionCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Mention id cannot be null or empty");
        }
    }
}
