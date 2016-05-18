using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.WebHost
{
    public class HelloWorldMetadata : ModuleMetadata
    {
        public HelloWorldMetadata()
        {
            Get["/api/helloWorld"] = new RouteMetadata { TestString = "w00t!!"};
        }
    }
}