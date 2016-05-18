using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class PathItem : Dictionary<string, Operation>
    {
        public List<Parameter> Parameters { get; set; }
        public string Path { get; set; }

        public PathItem()
        {
            Parameters = new List<Parameter>();
        }
    }
}