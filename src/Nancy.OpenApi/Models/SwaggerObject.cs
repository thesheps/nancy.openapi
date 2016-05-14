using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class SwaggerObject
    {
        public string Swagger => "2.0";
        public string BasePath => "v2";
        public string Host { get; set; }
        public List<string> Schemes { get; set; }
        public List<string> Consumes { get; set; }
        public List<string> Produces { get; set; }
        public InfoObject Info { get; set; }
        public PathsObject Paths { get; set; }
        public DefinitionsObject Definitions { get; set; }
        public ParametersDefinitionsObject Parameters { get; set; }
        public ResponsesObject Responses { get; set; }
        public SecurityDefinitionsObject SecurityDefinitions { get; set; }
        public List<SecurityRequirementObject> Security { get; set; }
        public List<TagObject> Tags { get; set; }
        public ExternalDocsObject ExternalDocs { get; set; }

        public SwaggerObject()
        {
            Schemes = new List<string>();
            Consumes = new List<string>();
            Produces = new List<string>();
            Info = new InfoObject();
            Paths = new PathsObject();
            Definitions = new DefinitionsObject();
            Parameters = new ParametersDefinitionsObject();
            Responses = new ResponsesObject();
            SecurityDefinitions = new SecurityDefinitionsObject();
            Security = new List<SecurityRequirementObject>();
            Tags = new List<TagObject>();
            ExternalDocs = new ExternalDocsObject();
        }
    }
}