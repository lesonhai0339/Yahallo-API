//AI generated
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace YAHALLO.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
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

        /// <summary>Push a notification to a specific user from server-side code.</summary>
        public static async Task SendToUserAsync(IHubContext<NotificationHub> hub, string userId, object payload)
        {
            await hub.Clients.Group($"user_{userId}").SendAsync("ReceiveNotification", payload);
        }
    }
}
