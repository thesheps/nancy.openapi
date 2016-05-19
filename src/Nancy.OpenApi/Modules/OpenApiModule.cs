using System.Linq;
using Nancy.OpenApi.Mappers;
using Nancy.OpenApi.Models;
using Nancy.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nancy.OpenApi.Modules
{
    public class OpenApiModule : NancyModule
    {
        public OpenApiModule()
        {
            Get["/api-docs"] = p => View["MissingComponent"];
        }

        public OpenApiModule(IApiDescription apiDescription, IRouteCacheProvider routeCacheProvider)
        {
            _routeCacheProvider = routeCacheProvider;
            _apiDescription = apiDescription;

            Get["/api-docs"] = p => View["Index"];
            Get["/swagger.json"] = p => GetSpecification();
        }

        private Response GetSpecification()
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
                    var operationObject = metadata == null ? new Operation { Description = route.Description } : metadata.ToOperation();

                    if (operationObject != null)
                        pathItem[route.Method] = operationObject;
                }

                apiSpecification.Paths[routeDescription.Key] = pathItem;
            }

            var response = (Response)JsonConvert.SerializeObject(apiSpecification, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            response.ContentType = "application/json";

            return response;
        }

        private readonly IApiDescription _apiDescription;
        private readonly IRouteCacheProvider _routeCacheProvider;
    }
}