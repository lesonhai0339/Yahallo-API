using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.UserRole;

namespace YAHALLO.Application.Queries.Features.Public.UserRole.GetAll
{
    public class GetAllUserRoleQuery: IRequest<List<UserRoleDto>>
    {    
    }
}
