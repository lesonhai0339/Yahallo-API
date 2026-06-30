using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.UserQuery.DTOs;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetByName
{
    public class GetUserByNameQuery : IRequest<List<UserDto>>
    {
        public GetUserByNameQuery() { }
        public GetUserByNameQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
