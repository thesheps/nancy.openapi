namespace Nancy.OpenApi.Infrastructure
{
    /// <summary>
    /// Describes an Api from the top-level. A simplistic implementation could derive the values
    /// using resource files.
    /// </summary>
    public interface IApiDescription
    {
        string Title { get; }
        string Description { get; }
        string ContactEmail { get; }
        string ContactName { get; }
        string ContactUrl { get; }
        string LicenseName { get; }
        string LicenseUrl { get; }
        string TermsOfService { get; }
        string Version { get; }
    }
}