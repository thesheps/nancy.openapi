using System.Collections.Generic;

namespace Nancy.OpenApi.Infrastructure
{
    public abstract class ModuleMetadata
    {
        public Dictionary<string, RouteMetadata> Get { get; }
        public Dictionary<string, RouteMetadata> Post { get; }
        public Dictionary<string, RouteMetadata> Put { get; }
        public Dictionary<string, RouteMetadata> Delete { get; }
        public Dictionary<string, RouteMetadata> Patch { get; }
        public Dictionary<string, RouteMetadata> Options { get; }
        public Dictionary<string, RouteMetadata> Head { get; }

        protected ModuleMetadata()
        {
            _metadata["GET"] = Get = new Dictionary<string, RouteMetadata>();
            _metadata["POST"] = Post = new Dictionary<string, RouteMetadata>();
            _metadata["PUT"] = Put = new Dictionary<string, RouteMetadata>();
            _metadata["DELETE"] = Delete = new Dictionary<string, RouteMetadata>();
            _metadata["PATCH"] = Patch = new Dictionary<string, RouteMetadata>();
            _metadata["OPTIONS"] = Options = new Dictionary<string, RouteMetadata>();
            _metadata["HEAD"] = Head = new Dictionary<string, RouteMetadata>();
        }

        public RouteMetadata GetRouteMetadata(string method, string path)
        {
            Dictionary<string, RouteMetadata> routes;
            _metadata.TryGetValue(method, out routes);

            if (routes == null) return null;

            RouteMetadata route;
            routes.TryGetValue(path, out route);

            return route;
        }

        private readonly Dictionary<string, Dictionary<string, RouteMetadata>> _metadata = new Dictionary<string, Dictionary<string, RouteMetadata>>();
    }
}