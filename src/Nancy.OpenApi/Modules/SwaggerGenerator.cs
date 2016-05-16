using System.Linq;
using Nancy.OpenApi.Infrastructure;
using Nancy.OpenApi.Mappers;
using Nancy.OpenApi.Models;
using Nancy.Routing;

namespace Nancy.OpenApi.Modules
{
    public interface ISwaggerGenerator
    {
        SwaggerObject Generate();
    }

    public class DefaultSwaggerGenerator : ISwaggerGenerator
    {
        public DefaultSwaggerGenerator(IRouteCacheProvider routeCacheProvider, IApiDescription apiDescription)
        {
            _routeCacheProvider = routeCacheProvider;
            _apiDescription = apiDescription;
        }

        public SwaggerObject Generate()
        {
            var routeCache = _routeCacheProvider.GetCache();
            var swaggerObject = _apiDescription.ToSwagger();
            var routeLookup = routeCache.Where(r => r.Key != typeof(OpenApiModule))
                .SelectMany(r => r.Value.Select(x => x.Item2))
                .ToLookup(x => x.Path);

            foreach (var lookup in routeLookup)
            {
                var pathItem = new PathItemObject { Path = lookup.Key };

                foreach (var route in lookup.ToList())
                {
                    switch (route.Method)
                    {
                        case "GET":
                            pathItem.Get = new OperationObject { Description = route.Description };
                            break;
                        case "POST":
                            pathItem.Post = new OperationObject { Description = route.Description };
                            break;
                        case "PUT":
                            pathItem.Put = new OperationObject { Description = route.Description };
                            break;
                        case "DELETE":
                            pathItem.Delete = new OperationObject { Description = route.Description };
                            break;
                        case "PATCH":
                            pathItem.Patch = new OperationObject { Description = route.Description };
                            break;
                        case "OPTIONS":
                            pathItem.Options = new OperationObject { Description = route.Description };
                            break;
                    }
                }

                swaggerObject.Paths[lookup.Key] = pathItem;
            }

            return swaggerObject;
        }

        private readonly IRouteCacheProvider _routeCacheProvider;
        private readonly IApiDescription _apiDescription;
    }
}