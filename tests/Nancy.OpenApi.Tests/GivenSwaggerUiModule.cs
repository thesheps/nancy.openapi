using Nancy.OpenApi.Infrastructure;
using Nancy.Testing;
using NUnit.Framework;

namespace Nancy.OpenApi.Tests
{
    public class GivenSwaggerUiModule
    {
        [Test]
        public void WhenIExecuteGetRequestForDefaultRoute_ThenSwaggerDocumentationIsRendered()
        {
            var browser = new Browser(new OpenApiBooststrapper());
            var response = browser.Get("/api-docs", (with) => { with.HttpRequest(); });

            response.Body["#swagger-ui-container"].ShouldExistOnce();
        }
    }
}