using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class PathItemObject
    {
        public OperationObject Get { get; set; }
        public OperationObject Put { get; set; }
        public OperationObject Post { get; set; }
        public OperationObject Delete { get; set; }
        public OperationObject Options { get; set; }
        public OperationObject Head { get; set; }
        public OperationObject Patch { get; set; }
        public List<ParameterObject> Parameters { get; set; }
        public string Path { get; set; }

        public PathItemObject()
        {
            Parameters = new List<ParameterObject>();
        }
    }
}