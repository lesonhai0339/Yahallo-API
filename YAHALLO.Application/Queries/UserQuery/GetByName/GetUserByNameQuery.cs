using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.GetByName
{
    public class GetUserByNameQuery: IRequest<List<UserDto>>
    {
        public GetUserByNameQuery() { }
        public GetUserByNameQuery(string name)
        {
            Name=name;
        }
        public string Name { get;set; }
    }
}
