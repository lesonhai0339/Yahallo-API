using MediatR;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.User.GetById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {


        public string Id { get; set; }
    }
}
