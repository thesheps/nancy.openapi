namespace Nancy.OpenApi.WebHost
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/api/helloWorld"] = p => null;
            Post["/api/helloWorld"] = p => null;
            Put["/api/helloWorld"] = p => null;
            Delete["/api/helloWorld"] = p => null;
            Patch["/api/helloWorld"] = p => null;
            Options["/api/helloWorld"] = p => null;
        }
    }
}