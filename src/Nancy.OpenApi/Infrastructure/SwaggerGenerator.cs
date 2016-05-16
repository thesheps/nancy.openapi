using System.Linq;
using Nancy.OpenApi.Mappers;
using Nancy.OpenApi.Models;
using Nancy.OpenApi.Modules;
using Nancy.Routing;

namespace Nancy.OpenApi.Infrastructure
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
                    var operationObject = new OperationObject
                    {
                        Description = route.Description,
                    };

                    switch (route.Method)
                    {
                        case "GET":
                            pathItem.Get = operationObject;
                            break;
                        case "POST":
                            pathItem.Post = operationObject;
                            break;
                        case "PUT":
                            pathItem.Put = operationObject;
                            break;
                        case "DELETE":
                            pathItem.Delete = operationObject;
                            break;
                        case "PATCH":
                            pathItem.Patch = operationObject;
                            break;
                        case "OPTIONS":
                            pathItem.Options = operationObject;
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