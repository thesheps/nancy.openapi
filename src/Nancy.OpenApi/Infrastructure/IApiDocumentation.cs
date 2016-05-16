namespace Nancy.OpenApi.Infrastructure
{
    public interface IApiDocumentation
    {
        string Title { get; set; }
        string Description { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        string LicenseName { get; set; }
        string LicenseUrl { get; set; }
        string TermsOfService { get; set; }
        string Version { get; set; }
    }
}