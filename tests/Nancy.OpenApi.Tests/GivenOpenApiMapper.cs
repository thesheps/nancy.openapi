using Nancy.OpenApi.Mappers;
using Nancy.OpenApi.Tests.Fakes;
using NUnit.Framework;

namespace Nancy.OpenApi.Tests
{
    public class GivenOpenApiMapper
    {
        [Test]
        public void WhenIRequestAnApiSpecification_BasePathIsPrefixedWithASlashWhenAppropriate()
        {
            var result = new FakeApiDescription().ToApiSpecification();
            Assert.AreEqual("/v2", result.BasePath);

            result = new FakeApiDescription
            {
                BasePath = "v99"
            }.ToApiSpecification();
            Assert.AreEqual("/v99", result.BasePath);
        }
    }
}
