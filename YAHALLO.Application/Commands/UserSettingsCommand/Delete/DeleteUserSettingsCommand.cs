using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Delete
{
    public class DeleteUserSettingsCommand: IRequest<string>
    {
        public string UserId { get; set; } = null!;
    }
}
