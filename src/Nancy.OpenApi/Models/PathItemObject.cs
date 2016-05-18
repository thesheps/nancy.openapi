using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class PathItemObject : Dictionary<string, OperationObject>
    {
        public List<ParameterObject> Parameters { get; set; }
        public string Path { get; set; }

        public PathItemObject()
        {
            Parameters = new List<ParameterObject>();
        }
    }
}