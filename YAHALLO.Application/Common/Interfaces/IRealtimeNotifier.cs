using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Interfaces
{
    public interface IRealtimeNotifier
    {
        Task SendToUserAsync(string userId, object payload, CancellationToken ct = default);
    }
}
