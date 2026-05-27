//AI generated
using FluentValidation;

namespace YAHALLO.Application.Commands.TagCommand.Create
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(128).WithMessage("Tên tag không được để trống và không vượt quá 128 ký tự");
        }
    }
}
