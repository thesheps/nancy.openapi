using System.Collections.Generic;
using Nancy.OpenApi.Models;

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
            Tags = new List<string> { "Test" },
            Parameters = new List<Parameter>
            {
                new Parameter
                {
                    Description = "The file to upload",
                    In = "formData",
                    Name = "upFile",
                    Type = "file"
                }
            }
        };

        public HelloWorldMetadata()
        {
            Post["/api/helloWorld"] = PostMetadata;
        }
    }
}