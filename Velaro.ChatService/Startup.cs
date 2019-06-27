using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Velaro.ChatService.Startup))]
namespace Velaro.ChatService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
