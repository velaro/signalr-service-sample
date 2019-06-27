using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Velaro.ChatService.Services
{
    public class RealtimeService
    {
        private readonly ConnectionService _connectionService;

        public RealtimeService()
        {
            _connectionService = new ConnectionService();
        }

        public async Task AddAgentToEngagementAsync(int userId, string engagementId)
        {
            var userConnections = await _connectionService.GetConnectionsForUserAsync(userId);
            var engagementHub = GlobalHost.ConnectionManager.GetHubContext<EngagementHub>();

            foreach(var userConnection in userConnections)
            {
                engagementHub.Groups.Add(userConnection.ConnectionId, GetEngagementLanguageGroup(engagementId, "en"));
                engagementHub.Groups.Add(userConnection.ConnectionId, GetEngagementGroup(engagementId));
            }
        }

        public Task SendMessage()
        {
            const string engagementId = "engagement-1";
            var hub = GlobalHost.ConnectionManager.GetHubContext<EngagementHub>();
            hub.Clients.Group(GetEngagementGroup(engagementId)).recieveEngagementMessage("engagement message");
            hub.Clients.Group(GetEngagementLanguageGroup(engagementId, "en")).receiveEngagementLanguageMessage("engagement language message");
            return Task.CompletedTask;
        }

        private string GetEngagementGroup(string engagementId)
        {
            return $"engagement_{engagementId}";
        }

        private string GetEngagementLanguageGroup(string engagementId, string language)
        {
            return $"engagement_{engagementId}_langauge_{language}";
        }
    }
}
