using System.Collections.Generic;
using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.Tests.Fakes
{
    public class FakeMetadata : ModuleMetadata
    {
        public PathMetadata PostMetadata = new PathMetadata
        {
            OperationId = "addTest",
            Summary = "Add a test object",
            Consumes = new List<string> { "application/json", "application/xml" },
            Produces = new List<string> { "application/json", "application/xml" },
            Tags = new List<string> { "Test" }
        };

        public FakeMetadata()
        {
            Post["/api/test"] = PostMetadata;
        }
    }
}