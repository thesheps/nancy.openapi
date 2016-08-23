using Nancy.OpenApi.Models;

namespace Nancy.OpenApi.Mappers
{
    public static class OpenApiMapper
    {
        public static ApiSpecification ToApiSpecification(this IApiDescription apiDescription)
        {
            return new ApiSpecification
            {
                ExternalDocs = new ExternalDocs
                {
                    Description  = apiDescription.ExternalDocsDescription,
                    Url = apiDescription.ExternalDocsUrl
                },
                Info = new Info
                {
                    Title = apiDescription.Title,
                    Description = apiDescription.Description,
                    Contact = new Contact
                    {
                        Email = apiDescription.ContactEmail,
                        Name = apiDescription.ContactName,
                        Url = apiDescription.ContactUrl
                    },
                    Licence = new License
                    {
                        Name = apiDescription.LicenseName,
                        Url = apiDescription.LicenseUrl
                    },
                    TermsOfService = apiDescription.TermsOfService,
                    Version = apiDescription.Version
                },
                BasePath = apiDescription.BasePath
            };
        }
    }
}