using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Restore
{
    public class RestoreUserSettingsCommand: IRequest<RestoreUserSettingsResult>   
    {
        public string UserId { get; set; } = null!;
    }
    public record RestoreUserSettingsResult(string Message);
}
