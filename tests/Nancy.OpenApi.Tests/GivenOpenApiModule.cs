using System.Linq;
using Nancy.OpenApi.Infrastructure;
using Nancy.OpenApi.Models;
using Nancy.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Nancy.OpenApi.Tests
{
    public class GivenOpenApiModule
    {
        [Test]
        public void WhenIMakeDocumentationRequestOnDefaultRoute_ThenSwaggerDocumentationIsRendered()
        {
            var browser = new Browser(new OpenApiBootstrapper());
            var response = browser.Get("/api-docs", (with) => { with.HttpRequest(); });

            response.Body["#swagger-ui-container"].ShouldExistOnce();
        }

        [Test]
        public void WhenIMakeSpecificationRequestOnDefaultRoute_ThenJsonSpecificationIsRetrieved()
        {
            var browser = new Browser(new OpenApiBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });

            var specs = JsonConvert.DeserializeObject<SwaggerObject>(response.Body.AsString());
            Assert.That(specs, Is.Not.Null);
            Assert.That(specs.Swagger, Is.EqualTo("2.0"));
        }

        [Test]
        public void WhenIHaveAModuleWithConfiguredRoutes_ThenJsonSpecificationRepresentsConfiguredRoutes()
        {
            var browser = new Browser(new OpenApiBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });

            var specs = JsonConvert.DeserializeObject<SwaggerObject>(response.Body.AsString());
            Assert.That(specs, Is.Not.Null);
            Assert.That(specs.Swagger, Is.EqualTo("2.0"));

            var path = specs.Paths.Any(p => p.Key == "/api/test");
            Assert.That(path, Is.True);
        }
    }
}