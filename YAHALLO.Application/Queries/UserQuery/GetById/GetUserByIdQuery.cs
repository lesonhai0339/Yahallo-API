using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserQuery.GetById
{
    public class GetUserByIdQuery: IRequest<UserDto>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;        
        }
        public string Id { get; set; }
    }
}
