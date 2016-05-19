using System.Collections.Generic;

namespace Nancy.OpenApi
{
    /// <summary>
    /// Create implementations of this class in order to add metadata to an existing Nancy module.
    /// </summary>
    public abstract class ModuleMetadata : Dictionary<string, Dictionary<string, PathMetadata>>
    {
        public Dictionary<string, PathMetadata> Get { get; }
        public Dictionary<string, PathMetadata> Post { get; }
        public Dictionary<string, PathMetadata> Put { get; }
        public Dictionary<string, PathMetadata> Delete { get; }
        public Dictionary<string, PathMetadata> Patch { get; }
        public Dictionary<string, PathMetadata> Options { get; }
        public Dictionary<string, PathMetadata> Head { get; }

        protected ModuleMetadata()
        {
            this["GET"] = Get = new Dictionary<string, PathMetadata>();
            this["POST"] = Post = new Dictionary<string, PathMetadata>();
            this["PUT"] = Put = new Dictionary<string, PathMetadata>();
            this["DELETE"] = Delete = new Dictionary<string, PathMetadata>();
            this["PATCH"] = Patch = new Dictionary<string, PathMetadata>();
            this["OPTIONS"] = Options = new Dictionary<string, PathMetadata>();
            this["HEAD"] = Head = new Dictionary<string, PathMetadata>();
        }

        public PathMetadata this[string method, string path]
        {
            get
            {
                Dictionary<string, PathMetadata> routes;
                TryGetValue(method.ToUpper(), out routes);

                if (routes == null) return null;

                PathMetadata routeMetadata;
                routes.TryGetValue(path, out routeMetadata);

                return routeMetadata;
            }
        }
    }
}