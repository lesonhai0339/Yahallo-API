using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.RoleQuery.GetAll
{
    public class GetAllRoleQuery: IRequest<List<RoleDto>>
    {
        public GetAllRoleQuery() { }
    }
}
