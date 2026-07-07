using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.Hubs.UpdateLastActive
{
    public class UpdateLastActiveCommand: INotification
    {
        public required string UserId { get; set; } 
    }
}
