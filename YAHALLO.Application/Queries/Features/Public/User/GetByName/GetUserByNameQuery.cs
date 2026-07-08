using MediatR;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.User.GetByName
{
    public class GetUserByNameQuery : IRequest<List<UserDto>>
    {


        public string Name { get; set; }
    }
}
