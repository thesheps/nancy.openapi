using System.Collections.Generic;

namespace Nancy.OpenApi
{
    /// <summary>
    /// Create implementations of this class in order to add metadata to an existing Nancy route/path.
    /// </summary>
    public class PathMetadata
    {
        public string OperationId { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public List<string> Consumes { get; set; }
        public List<string> Produces { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, string> Responses { get; set; }
    }
}