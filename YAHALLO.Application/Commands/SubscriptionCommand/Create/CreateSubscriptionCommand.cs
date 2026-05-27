//AI generated
using MediatR;
using YAHALLO.Domain.Enums.SubscriptionEnums;

namespace YAHALLO.Application.Commands.SubscriptionCommand.Create
{
    public class CreateSubscriptionCommand : IRequest<string>
    {
        public SubscriptionPlan Plan { get; set; }
        /// <summary>Number of days the subscription is valid.</summary>
        public int DurationDays { get; set; } = 30;
    }
}
