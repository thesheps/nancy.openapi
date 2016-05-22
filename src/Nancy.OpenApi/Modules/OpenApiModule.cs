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

        public OpenApiModule(IApiSpecificationFactory apiSpecificationFactory)
        {
            _apiSpecificationFactory = apiSpecificationFactory;

            Get["/api-docs"] = p => View["Index"];
            Get["/swagger.json"] = p => GetSpecification();
        }

        private Response GetSpecification()
        {
            var apiSpecification = _apiSpecificationFactory.Create();
            var response = (Response)JsonConvert.SerializeObject(apiSpecification, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            response.ContentType = "application/json";

            return response;
        }

        private readonly IApiSpecificationFactory _apiSpecificationFactory;
    }
}