using System;
using Nancy.OpenApi.Infrastructure;
using Nancy.OpenApi.Models;
using Nancy.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nancy.OpenApi.Modules
{
    public class OpenApiModule : NancyModule
    {
        public OpenApiModule(IRouteCacheProvider routeCacheProvider, IApiDocumentation apiDocumentation)
        {
            _routeCacheProvider = routeCacheProvider;
            _apiDocumentation = apiDocumentation;

            Get["/api-docs"] = p => View["Index"];
            Get["/swagger.json"] = p => GetDocumentation();
        }

        private Response GetDocumentation()
        {
            var response = (Response)JsonConvert.SerializeObject(GetSwagger(), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            response.ContentType = "application/json";

            return response;
        }

        private SwaggerObject GetSwagger()
        {
            var routeCache = _routeCacheProvider.GetCache();

            foreach (var routeInfo in routeCache)
            {
                Console.WriteLine(routeInfo);
            }

            return new SwaggerObject
            {
                Info = new InfoObject
                {
                    Title = _apiDocumentation.Title,
                    Description = _apiDocumentation.Description,
                    Contact = new ContactObject
                    {
                        Email = _apiDocumentation.Email,
                        Name = _apiDocumentation.Name,
                        Url = _apiDocumentation.Url
                    },
                    Licence = new LicenceObject
                    {
                        Name = _apiDocumentation.LicenseName,
                        Url = _apiDocumentation.LicenseUrl
                    },
                    TermsOfService = _apiDocumentation.TermsOfService,
                    Version = _apiDocumentation.Version
                }
            };
        }

        private readonly IRouteCacheProvider _routeCacheProvider;
        private readonly IApiDocumentation _apiDocumentation;
    }
}