using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.UserQuery.DTOs;

namespace YAHALLO.Application.Queries.UserQuery.GetByIdDeleted
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
