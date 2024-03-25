using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllDeleted
{
    public class GetAllRoleDeletedQuery: IRequest<List<RoleDto>>
    {
        public GetAllRoleDeletedQuery() { }
    }
}
