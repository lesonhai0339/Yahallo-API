using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetByIdDeleted
{
    public class GetUserByIdDeleted : IRequest<UserDto>
    {
        public GetUserByIdDeleted() { }
        public GetUserByIdDeleted(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
