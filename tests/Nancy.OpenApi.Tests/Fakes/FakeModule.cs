namespace Nancy.OpenApi.Tests.Fakes
{
    public class FakeModule : NancyModule
    {
        public FakeModule()
        {
            Get["/api/test"] = p => null;
            Post["/api/test"] = p => null;
            Put["/api/test"] = p => null;
            Delete["/api/test"] = p => null;
            Patch["/api/test"] = p => null;
            Options["/api/test"] = p => null;
        }
    }
}