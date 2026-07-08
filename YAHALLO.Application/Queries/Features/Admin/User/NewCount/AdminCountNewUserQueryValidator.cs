using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.User.NewCount
{
    public sealed class AdminCountNewUserQueryValidator: AbstractValidator<AdminCountNewUserQuery>
    {
        public AdminCountNewUserQueryValidator()
        {
            RuleFor(x => x.PageNo).GreaterThan(0).WithMessage("Page number must be greater than 0.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than 0.");

            RuleFor(x => x.To).GreaterThan(x => x.From).WithMessage("The 'To' date must be greater than the 'From' date.");
            RuleFor(x => x).Must(x =>
    x.CountBy != AdminUserCountBy.Day || (x.To - x.From).Days <= 366)
    .WithMessage("Time too long for filter by day");
        }
    }
}
