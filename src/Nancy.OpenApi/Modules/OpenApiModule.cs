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

        public OpenApiModule(ISwaggerGenerator swaggerGenerator)
        {
            _swaggerGenerator = swaggerGenerator;

            Get["/api-docs"] = p => View["Index"];
            Get["/swagger.json"] = p => GetSpecification();
        }

        private Response GetSpecification()
        {
            var response = (Response)JsonConvert.SerializeObject(_swaggerGenerator.Generate(), new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

            response.ContentType = "application/json";

            return response;
        }

        private readonly ISwaggerGenerator _swaggerGenerator;
    }
}