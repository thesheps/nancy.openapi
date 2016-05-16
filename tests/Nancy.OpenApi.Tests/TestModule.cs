namespace Nancy.OpenApi.Tests
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/api/test"] = p => GetTest();
        }

        private static object GetTest()
        {
            return null;
        }
    }
}