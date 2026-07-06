using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.UserQuery.DTOs;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.UserQuery.GetUserDetail
{
    public class GetUserDetailQuery: IRequest<UserDetailDto>
    {
        public string UserId { get; init; } = null!;
    }
}
