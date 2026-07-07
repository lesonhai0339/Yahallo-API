using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserDaily;

namespace YAHALLO.Application.Commands.UserCommand.DailyActivity
{
    public class UpdateDailyActivityNotification: INotification
    {
        public string UserId { get; init; } = null!;
        public UserDailyType Type { get; init; }    

    }
}
