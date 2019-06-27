using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Velaro.ChatService.Services;

namespace Velaro.ChatService.Controllers
{
    public class AgentChatController : ApiController
    {
        private RealtimeService _realtimeService;

        public AgentChatController()
        {
            _realtimeService = new RealtimeService();
        }

        // this is just here to show AddAgentToEngagement
        // can be called from the api or the engagement hub connect event.

        //public async Task<IHttpActionResult> JoinAgent()
        //{
        //    await _realtimeService.AddAgentToEngagementAsync(1, "engagement-1");
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        public async Task<IHttpActionResult> Post()
        {
            await _realtimeService.SendMessage();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
