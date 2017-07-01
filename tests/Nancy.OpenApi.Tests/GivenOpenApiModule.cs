using Nancy.OpenApi.Models;
using Nancy.OpenApi.Tests.Fakes;
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
            var browser = new Browser(new TestBootstrapper());
            var response = browser.Get("/api-docs", (with) => { with.HttpRequest(); });

            response.Body["#swagger-ui-container"].ShouldExistOnce();
        }

        [Test]
        public void WhenIHaveAModuleWithConfiguredRoutes_ThenBasePathIsConfiguredCorrectly()
        {
            var browser = new Browser(new TestBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });
            var specs = JsonConvert.DeserializeObject<ApiSpecification>(response.Body.AsString());

            Assert.That(specs, Is.Not.Null);
            Assert.That(specs.Swagger, Is.EqualTo("2.0"));
        }

        [Test]
        public void WhenIHaveAModuleWithConfiguredRoutes_ThenApiSpecificationIsMappedCorrectly()
        {
            var browser = new Browser(new TestBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });
            var specs = JsonConvert.DeserializeObject<ApiSpecification>(response.Body.AsString());
            var path = specs.Paths["/api/test"];

            Assert.That(specs, Is.Not.Null);
            Assert.That(specs.Swagger, Is.EqualTo("2.0"));
            Assert.That(specs.BasePath, Is.EqualTo(_apiDescription.BasePath));
            Assert.That(specs.Info.Contact.Name, Is.EqualTo(_apiDescription.ContactName));
            Assert.That(specs.Info.Contact.Email, Is.EqualTo(_apiDescription.ContactEmail));
            Assert.That(specs.Info.Contact.Url, Is.EqualTo(_apiDescription.ContactUrl));
            Assert.That(specs.Info.Description, Is.EqualTo(_apiDescription.Description));
            Assert.That(specs.Info.Licence.Name, Is.EqualTo(_apiDescription.LicenseName));
            Assert.That(specs.Info.Licence.Url, Is.EqualTo(_apiDescription.LicenseUrl));
            Assert.That(specs.Info.TermsOfService, Is.EqualTo(_apiDescription.TermsOfService));
            Assert.That(specs.Info.Title, Is.EqualTo(_apiDescription.Title));
            Assert.That(specs.Info.Version, Is.EqualTo(_apiDescription.Version));
            Assert.That(path, Is.Not.Null);
        }

        [Test]
        public void WhenIHaveAModuleWithConfiguredRoutes_ThenManuallyMappedSpecificationIsCorrect()
        {
            var browser = new Browser(new TestBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });
            var specs = JsonConvert.DeserializeObject<ApiSpecification>(response.Body.AsString());
            var path = specs.Paths["/api/test"];
            var postPath = path["post"];

            Assert.That(postPath.Description, Is.EqualTo(_metadata.PostMetadata.Description));
            Assert.That(postPath.Summary, Is.EqualTo(_metadata.PostMetadata.Summary));
            Assert.That(postPath.OperationId, Is.EqualTo(_metadata.PostMetadata.OperationId));
        }

        [Test]
        public void WhenIHaveAModuleWithConfiguredRoutes_ThenJsonMappedSpecificationIsCorrect()
        {
            var browser = new Browser(new TestBootstrapper());
            var response = browser.Get("/swagger.json", (with) => { with.Header("Accept", "application/json"); });
            var specs = JsonConvert.DeserializeObject<ApiSpecification>(response.Body.AsString());
            var path = specs.Paths["/api/test"];

            var getPath = path["get"];
            Assert.That(getPath.Description, Is.EqualTo(_metadata.GetMetadata.Description));
            Assert.That(getPath.OperationId, Is.EqualTo(_metadata.GetMetadata.OperationId));

            var p1 = getPath.Parameters[0];
            var p2 = _metadata.GetMetadata.Parameters[0];
            Assert.That(p1.CollectionFormat, Is.EqualTo("multi"));
            Assert.That(p1.Description, Is.EqualTo(p2.Description));
            Assert.That(p1.In, Is.EqualTo(p2.In));
            Assert.That(p1.Name, Is.EqualTo(p2.Name));
            Assert.That(p1.Required, Is.EqualTo(p2.Required));
            Assert.That(p1.Schema.Type, Is.EqualTo(p2.Schema.Type));
            Assert.That(p1.Schema.Properties, Is.EqualTo(p2.Schema.Properties));
            Assert.That(getPath.Summary, Is.EqualTo(_metadata.GetMetadata.Summary));
        }


        private readonly IApiDescription _apiDescription = new FakeApiDescription();
        private readonly FakeMetadata _metadata = new FakeMetadata();
    }
}