//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.NotificationCommand.MarkRead
{
    public class MarkNotificationReadCommand : IRequest<string>
    {
        /// <summary>Pass null to mark ALL unread notifications as read.</summary>
        public string? NotificationId { get; set; }
    }
}
