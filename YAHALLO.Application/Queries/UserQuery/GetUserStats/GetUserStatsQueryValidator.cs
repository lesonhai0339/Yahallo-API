using FluentValidation;

namespace YAHALLO.Application.Queries.UserQuery.GetUserStats
{
    public class GetUserStatsQueryValidator: AbstractValidator<GetUserStatsQuery>
    {
        public GetUserStatsQueryValidator()
        {
            RuleFor(x => x.To).GreaterThan(x => x.From).WithMessage("The 'To' date must be greater than the 'From' date.");
            RuleFor(x => x).Must(x =>
    x.FilterBy != Domain.Enums.UserDaily.UserDailyFilterBy.Day || (x.To - x.From).Days <= 366)
    .WithMessage("Time too long for filter by day");
        }
    }
}
