//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.TagCommand.Update
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id tag không được để trống");
        }
    }
}
