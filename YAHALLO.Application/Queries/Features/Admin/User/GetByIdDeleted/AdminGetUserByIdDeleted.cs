using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetByIdDeleted
{
    public sealed class AdminGetUserByIdDeleted : IRequest<AdminUserDto>
    {
        public string Id { get; set; } = null!;
    }
}
