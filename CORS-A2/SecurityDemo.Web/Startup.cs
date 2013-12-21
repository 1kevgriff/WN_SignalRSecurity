using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityDemo.Web.Startup))]
namespace SecurityDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.MapSignalR();
            app.Map("/signalr", mapping =>
            {
                mapping.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration();
                hubConfiguration.EnableJSONP = true; // older browsers require this!

                mapping.RunSignalR(hubConfiguration);
            });
        }
    }
}
