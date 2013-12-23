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
            //app.MapSignalR();

            app.Map("/SignalR", mapping =>
            {
                var corsOption = new Microsoft.Owin.Cors.CorsOptions();
                mapping.UseCors(corsOption);

                HubConfiguration hubConfiguration = new HubConfiguration();
                mapping.RunSignalR(hubConfiguration);
            });
        }
    }
}
