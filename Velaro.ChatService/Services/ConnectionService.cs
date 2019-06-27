using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velaro.ChatService.Models;

namespace Velaro.ChatService.Services
{
    public class ConnectionService
    {
        private static readonly List<UserConnection> _connections = new List<UserConnection>();

        public Task UpsertAsync(UserConnection userConnection)
        {
            _connections.Add(userConnection);
            return Task.CompletedTask;
        }

        internal Task<IEnumerable<UserConnection>> GetConnectionsForUserAsync(int userId)
        {
            var connections = _connections.Where(x => x.UserId == userId);
            return Task.FromResult(connections);
        }
    }
}
