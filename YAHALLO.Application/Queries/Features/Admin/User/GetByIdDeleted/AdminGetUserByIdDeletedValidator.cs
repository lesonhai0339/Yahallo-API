using FluentValidation;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetByIdDeleted
{
    public sealed class AdminGetUserByIdDeletedValidator : AbstractValidator<AdminGetUserByIdDeleted>
    {
        public AdminGetUserByIdDeletedValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id không được bỏ trống");
        }
    }
}
