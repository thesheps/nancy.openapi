using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class SchemaObject
    {
        public Dictionary<string, PropertyObject> Properties { get; set; }
        public string Type { get; set; }
    }
}