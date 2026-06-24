using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.UserSettingsQuery.GetById
{
    public class GetUserSettingsQuery: IRequest<UserSettingsDto>
    {
    }
}
