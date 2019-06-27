using System.Collections.Generic;
using Velaro.ChatService.Models;

namespace Velaro.ChatService.Services
{
    public class EngagementService
    {
        public IEnumerable<Engagement> GetJoinedChats(int userId)
        {
            return new List<Engagement>
            {
                new Engagement{ Id = "engagement-1" }
            };
        }
    }
}
