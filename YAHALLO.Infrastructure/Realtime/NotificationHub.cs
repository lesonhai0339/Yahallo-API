using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.Hubs.UpdateLastActive;

namespace YAHALLO.Infrastructure.Realtime
{
    [Authorize]
    public class NotificationHub : Hub
    {
        private readonly IMediator _sender;
        private readonly ILogger<NotificationHub> _logger;
        public NotificationHub(IMediator sender, ILogger<NotificationHub> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
                await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user_{userId}");

            await base.OnDisconnectedAsync(exception);
        }
        public async Task Ping()
        {
            try
            {
                var userId = Context.UserIdentifier;
                if (string.IsNullOrEmpty(userId)) 
                    return;

                await _sender.Publish(new UpdateLastActiveNotification { UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ping failed for user {UserId}", Context.UserIdentifier);
                throw new HubException("Ping failed");
            }
        }

        /// <summary>Push a notification to a specific user from server-side code.</summary>
        public static async Task SendToUserAsync(IHubContext<NotificationHub> hub, string userId, object payload)
        {
            await hub.Clients.Group($"user_{userId}").SendAsync("ReceiveNotification", payload);
        }
    }
}
