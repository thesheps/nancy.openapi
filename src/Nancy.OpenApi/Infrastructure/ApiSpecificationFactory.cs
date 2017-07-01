using System.Linq;
using Nancy.OpenApi.Mappers;
using Nancy.OpenApi.Models;
using Nancy.OpenApi.Modules;
using Nancy.Routing;

namespace Nancy.OpenApi.Infrastructure
{
    public interface IApiSpecificationFactory
    {
        ApiSpecification Create();
    }

    public class ApiSpecificationFactory : IApiSpecificationFactory
    {
        public ApiSpecificationFactory(IRouteCacheProvider routeCacheProvider, IApiDescription apiDescription)
        {
            _routeCacheProvider = routeCacheProvider;
            _apiDescription = apiDescription;
        }

        public ApiSpecification Create()
        {
            var routeCache = _routeCacheProvider.GetCache();
            var apiSpecification = _apiDescription.ToApiSpecification();

            var routes = routeCache.Where(r => r.Key != typeof(OpenApiModule))
                .SelectMany(r => r.Value.Select(x => x.Item2))
                .ToLookup(x => x.Path);

            foreach (var routeDescription in routes)
            {
                var pathItem = new PathItem { Path = routeDescription.Key };

                foreach (var route in routeDescription.ToList())
                {
                    var metadata = route.Metadata.Retrieve<PathMetadata>();
                    var operation = metadata == null ? new Operation { Description = route.Description } : metadata.ToOperation();

                    if (operation != null) pathItem[route.Method] = operation;
                }

                apiSpecification.Paths[routeDescription.Key] = pathItem;
            }

            return apiSpecification;
        }

        private readonly IRouteCacheProvider _routeCacheProvider;
        private readonly IApiDescription _apiDescription;
    }
}