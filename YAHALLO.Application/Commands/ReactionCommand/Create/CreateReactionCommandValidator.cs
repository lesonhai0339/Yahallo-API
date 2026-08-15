//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    public class CreateReactionCommandValidator : AbstractValidator<CreateReactionCommand>
    {
        public CreateReactionCommandValidator()
        {
            RuleFor(x => x.TargetId).NotNull().NotEmpty().WithMessage("TargetId không được bỏ trống");
            RuleFor(x => x.Reaction).NotNull().WithMessage("Reaction không được bỏ trống");
            RuleFor(x => x.ReactionTo).IsInEnum().WithMessage("ReactionTo không hợp lệ");
        }
    }
}
