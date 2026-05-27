//AI generated
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.SubscriptionEnums;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class SubscriptionEntity : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;

        public SubscriptionPlan Plan { get; set; }
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive => Status == SubscriptionStatus.Active && EndDate >= DateTime.Now;
    }
}
