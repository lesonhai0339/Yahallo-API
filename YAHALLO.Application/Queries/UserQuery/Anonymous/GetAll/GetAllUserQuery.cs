using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetAll
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {
        public GetAllUserQuery() { }
    }
}
