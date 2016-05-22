using System.Collections.Generic;

namespace Nancy.OpenApi.Tests.Fakes
{
    public class FakeMetadata : ModuleMetadata
    {
        public PathMetadata GetMetadata = FakeModuleResources.GetApiTest;

        public PathMetadata PostMetadata = new PathMetadata
        {
            OperationId = "addTest",
            Summary = "Add a test object",
            Consumes = new List<string> { "application/json", "application/xml" },
            Produces = new List<string> { "application/json", "application/xml" },
            Tags = new List<string> { "Test" },
            Responses = new Dictionary<string, Models.Response>()
        };

        public FakeMetadata()
        {
            Post["/api/test"] = PostMetadata;
            Get["/api/test"] = GetMetadata;
        }
    }
}