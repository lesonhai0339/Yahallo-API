using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAllDeleted
{
    public class GetAllUserRoleDeletedQuery: IRequest<List<UserRoleDto>>
    {
        public GetAllUserRoleDeletedQuery() { }
    }
}
