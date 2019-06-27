using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Velaro.ChatService.Models;
using Velaro.ChatService.Services;

namespace Velaro.ChatService
{
    public class EngagementHub : Hub
    {
        private readonly ConnectionService _connectionService;
        private readonly EngagementService _engagementService;
        private readonly RealtimeService _realtimeService;

        public EngagementHub()
        {
            _connectionService = new ConnectionService();
            _engagementService = new EngagementService();
            _realtimeService = new RealtimeService();
        }

        public override async Task OnConnected()
        {
            await PersistUserConnectionAsync().ConfigureAwait(false);
            await ConnectUserAsync().ConfigureAwait(false);
        }

        private async Task PersistUserConnectionAsync()
        {
            await _connectionService.UpsertAsync(new UserConnection
            {
                ConnectionId = Context.ConnectionId,
                UserId = 1
            }).ConfigureAwait(false);
        }

        private async Task ConnectUserAsync()
        {
            var userId = 1;

            foreach(var engagement in _engagementService.GetJoinedChats(userId))
            {
                await _realtimeService.AddAgentToEngagementAsync(userId, engagement.Id);
            }
        }
    }
}
