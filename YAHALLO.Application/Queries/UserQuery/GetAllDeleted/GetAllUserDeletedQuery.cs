using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.UserQuery.DTOs;

namespace YAHALLO.Application.Queries.UserQuery.GetAllDeleted
{
    public class GetAllUserDeletedQuery : IRequest<List<UserDto>>
    {
        public GetAllUserDeletedQuery() { }
    }
}
