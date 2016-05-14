using Nancy.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nancy.OpenApi.Modules
{
    public class OpenApiModule : NancyModule
    {
        public OpenApiModule()
        {
            Get["/api-docs"] = p => View["Index"];
            Get["/api-specs"] = p => GetDocumentation();
        }

        private static Response GetDocumentation()
        {
            var response = (Response)JsonConvert.SerializeObject(new SwaggerObject(), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            response.ContentType = "application/json";
            return response;
        }
    }
}