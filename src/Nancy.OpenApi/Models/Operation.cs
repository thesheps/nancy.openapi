using System.Collections.Generic;

namespace Nancy.OpenApi.Models
{
    public class Operation
    {
        public List<string> Tags { get; set; }
        public List<string> Consumes { get; set; }
        public List<string> Produces { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string OperationId { get; set; }

        public Operation()
        {
            Tags = new List<string>();
            Consumes = new List<string>();
            Produces = new List<string>();
        }
    }
}