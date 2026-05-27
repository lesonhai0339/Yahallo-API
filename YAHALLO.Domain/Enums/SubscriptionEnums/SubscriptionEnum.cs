//AI generated
using System.ComponentModel;

namespace YAHALLO.Domain.Enums.SubscriptionEnums
{
    public enum SubscriptionPlan
    {
        [Description("Miễn phí")]
        Free = 1,

        [Description("Pro")]
        Pro = 2,

        [Description("Vip")]
        Vip = 3,

        [Description("Master")]
        Master = 4,
    }

    public enum SubscriptionStatus
    {
        Active = 1,
        Expired = 2,
        Cancelled = 3,
    }
}
