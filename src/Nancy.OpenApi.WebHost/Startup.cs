using Microsoft.Owin;
using Nancy.OpenApi.WebHost;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Nancy.OpenApi.WebHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}