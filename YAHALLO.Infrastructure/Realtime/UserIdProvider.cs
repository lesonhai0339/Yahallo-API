using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;


namespace YAHALLO.Infrastructure.Realtime
{
    public class UserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
       => connection.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
    }
}
