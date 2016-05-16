using Nancy.OpenApi.Infrastructure;

namespace Nancy.OpenApi.WebHost
{
    /// <summary>
    /// Simple IApiDescription implementation which derives its values from a resource file.
    /// </summary>
    public class ApiDescription : IApiDescription
    {
        public string Title => Resources.Title;
        public string Description => Resources.Description;
        public string ContactEmail => Resources.ContactEmail;
        public string ContactName => Resources.ContactName;
        public string ContactUrl => Resources.ContactUrl;
        public string LicenseName => Resources.LicenseName;
        public string LicenseUrl => Resources.LicenseUrl;
        public string TermsOfService => Resources.TermsOfService;
        public string Version => Resources.Version;
    }
}