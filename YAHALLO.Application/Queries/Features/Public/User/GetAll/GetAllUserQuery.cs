using MediatR;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.User.GetAll
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {

    }
}
