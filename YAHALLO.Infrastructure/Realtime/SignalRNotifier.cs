using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Infrastructure.Realtime
{
    public class SignalRNotifier: IRealtimeNotifier
    {
        private readonly IHubContext<NotificationHub> _hub;
        public SignalRNotifier(IHubContext<NotificationHub> hub) => _hub = hub;
        public Task SendToUserAsync(string userId, object payload, CancellationToken ct = default)
        => _hub.Clients.User(userId).SendAsync("ReceiveNotification", payload, ct);
    }
}
