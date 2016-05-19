using System.Collections.Generic;

namespace Nancy.OpenApi.WebHost
{
    public class HelloWorldMetadata : ModuleMetadata
    {
        public PathMetadata PostMetadata = new PathMetadata
        {
            OperationId = "addTest",
            Summary = "Add a test object",
            Consumes = new List<string> { "application/json", "application/xml" },
            Produces = new List<string> { "application/json", "application/xml" },
            Tags = new List<string> { "Test" }
        };

        public HelloWorldMetadata()
        {
            Post["/api/helloWorld"] = PostMetadata;
        }
    }
}