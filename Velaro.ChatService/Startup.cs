using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(Velaro.ChatService.Startup))]
namespace Velaro.ChatService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR(); // use local signalr
            var connectionCount = 15;
            var count = Environment.GetEnvironmentVariable("ConnectionCount");
            if (!String.IsNullOrEmpty(count))
            {
                if (int.TryParse(count, out int c))
                {
                    connectionCount = c;
                }
            }
            // Any connection or hub wire up and configuration should go here
            app.MapAzureSignalR(this.GetType().FullName, options => {
                options.ConnectionCount = connectionCount;
            });
        }
    }
}
