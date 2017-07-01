using Nancy.Bootstrapper;
using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.WebHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration => this.WithOpenApi(Conventions, ApplicationContainer);
    }
}