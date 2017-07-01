using Nancy.Bootstrapper;
using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.Tests
{
    public class TestBootstrapper : DefaultNancyBootstrapper
    {
        public TestBootstrapper()
        {
            this.WithOpenApi(Conventions, ApplicationContainer);
        }

        protected override NancyInternalConfiguration InternalConfiguration => this.WithOpenApi();
    }
}