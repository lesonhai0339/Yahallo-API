//AI generated
using FluentValidation;
using YAHALLO.Domain.Enums.SubscriptionEnums;

namespace YAHALLO.Application.Commands.SubscriptionCommand.Create
{
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidator()
        {
            RuleFor(x => x.Plan).IsInEnum().WithMessage("Gói đăng ký không hợp lệ");
            RuleFor(x => x.Plan).NotEqual(SubscriptionPlan.Free).WithMessage("Không thể đăng ký gói Free");
            RuleFor(x => x.DurationDays).GreaterThan(0).WithMessage("Thời hạn đăng ký phải lớn hơn 0 ngày");
        }
    }
}
