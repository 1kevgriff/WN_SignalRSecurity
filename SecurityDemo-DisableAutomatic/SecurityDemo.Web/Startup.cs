using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityDemo.Web.Startup))]
namespace SecurityDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR(new HubConfiguration()
            {
                EnableJavaScriptProxies = false
            });
        }
    }
}
