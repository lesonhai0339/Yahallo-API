//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.TagCommand.Delete
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id tag không được để trống");
        }
    }
}
