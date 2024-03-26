using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAll
{
    public class GetAllUserRoleQuery: IRequest<List<UserRoleDto>>
    {
        public GetAllUserRoleQuery() { }    
    }
}
