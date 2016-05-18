using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class Schema
    {
        public Dictionary<string, Property> Properties { get; set; }
        public string Type { get; set; }
    }
}