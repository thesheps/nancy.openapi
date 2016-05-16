using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.Tests.Fakes
{
    public class FakeApiDescription : IApiDescription
    {
        public string Title => "My Test Api";
        public string Description => "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a elit nulla.";
        public string ContactEmail => "someone@somewhere.com";
        public string ContactName => "Joe Bloggs";
        public string ContactUrl => "mytestapi.com";
        public string LicenseName => "MIT";
        public string LicenseUrl => "https://raw.githubusercontent.com/thesheps/nancy.openapi/master/LICENSE";
        public string TermsOfService => "In turpis nunc, vestibulum ac neque quis, lobortis convallis metus. Sed feugiat orci id augue mattis, sit amet consectetur metus porta.";
        public string Version => "1.0";
        public string ExternalDocsDescription => "Wiki community article";
        public string ExternalDocsUrl => "www.testdocs";
    }
}