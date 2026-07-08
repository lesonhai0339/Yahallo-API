using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.UserSettings;

namespace YAHALLO.Application.Queries.Features.Public.UserSettings.GetById
{
    public class GetUserSettingsQuery: IRequest<UserSettingsDto>
    {
    }
}
