using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class ApiSpecification
    {
        public string Swagger => "2.0";
        public string BasePath { get; set; }
        public string Host { get; set; }
        public List<string> Schemes { get; set; }
        public List<string> Consumes { get; set; }
        public List<string> Produces { get; set; }
        public Info Info { get; set; }
        public Paths Paths { get; set; }
        public Definitions Definitions { get; set; }
        public ParametersDefinitions Parameters { get; set; }
        public Responses Responses { get; set; }
        public SecurityDefinitions SecurityDefinitions { get; set; }
        public List<SecurityRequirement> Security { get; set; }
        public List<Tag> Tags { get; set; }
        public ExternalDocs ExternalDocs { get; set; }

        public ApiSpecification()
        {
            Schemes = new List<string>();
            Consumes = new List<string>();
            Produces = new List<string>();
            Info = new Info();
            Paths = new Paths();
            Definitions = new Definitions();
            Parameters = new ParametersDefinitions();
            Responses = new Responses();
            SecurityDefinitions = new SecurityDefinitions();
            Security = new List<SecurityRequirement>();
            Tags = new List<Tag>();
            ExternalDocs = new ExternalDocs();
        }
    }
}