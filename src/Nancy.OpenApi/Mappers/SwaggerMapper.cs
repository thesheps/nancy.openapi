using Nancy.OpenApi.Infrastructure;
using Nancy.OpenApi.Models;

namespace Nancy.OpenApi.Mappers
{
    public static class SwaggerMapper
    {
        public static SwaggerObject ToSwagger(this IApiDescription apiDescription)
        {
            return new SwaggerObject
            {
                Info = new InfoObject
                {
                    Title = apiDescription.Title,
                    Description = apiDescription.Description,
                    Contact = new ContactObject
                    {
                        Email = apiDescription.ContactEmail,
                        Name = apiDescription.ContactName,
                        Url = apiDescription.ContactUrl
                    },
                    Licence = new LicenceObject
                    {
                        Name = apiDescription.LicenseName,
                        Url = apiDescription.LicenseUrl
                    },
                    TermsOfService = apiDescription.TermsOfService,
                    Version = apiDescription.Version
                }
            };
        }
    }
}