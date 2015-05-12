using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace StockTicker
{
    public class EmmitStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR("/emmit", new HubConfiguration()
                {
                    EnableJavaScriptProxies = true
                });
        }
    }
}