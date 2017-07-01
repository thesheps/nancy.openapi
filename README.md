# nancy.openapi
OpenApi/swagger documentation generation for NancyFX.  Integration with this repository is designed to be as trivial as possible:

- Pull down the NuGet package.
- Create an implementation of the IApiDescription interface to describe your Api at the top-level (Ie author, license information).
- Create a derivative of MetadataModule for every module you wish to serve Api documentation from.

2 new routes will be added at the root of your application:

- /swagger.json

This is the combined documentation which is automatically generated using each of the metadata modules.

- /api-docs

This is a bundled implementation of the <a href="http://swagger.io/swagger-ui/">Swagger Ui</a> project.  It consumes the specification created at the swagger.json route.

---

# Example

- Install-Package Nancy.OpenApi
- Extend Bootstrapper:

```c#
using Nancy.Bootstrapper;
using Nancy.OpenApi.Infrastructure;

namespace MyApiProject
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        ///...
    
        protected override NancyInternalConfiguration InternalConfiguration => this.WithOpenApi(Conventions, ApplicationContainer);
    
        ///...
    }
}
```

- Create Metadata Implementation

## Module
```c#
namespace MyExampleApi
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
```

## Metadata
```c#
using System.Collections.Generic;

namespace MyExampleApi
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
```

**Make sure your Metadata module matches your Nancy Module. HelloWorldModule should have a ModuleMetadata derivative named HelloWorldMetadata**

For further information as to what information to include in your metadata module, please refer to the official swagger/open api documentation over at [The Official Docs](https://swagger.io/swagger-ui/) :)
