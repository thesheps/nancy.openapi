using System.Collections.Generic;

namespace Nancy.OpenApi.Infrastructure
{
    public abstract class OpenApiModuleMetadata : Dictionary<string, Dictionary<string, OpenApiRouteMetadata>>
    {
        public Dictionary<string, OpenApiRouteMetadata> Get { get; }
        public Dictionary<string, OpenApiRouteMetadata> Post { get; }
        public Dictionary<string, OpenApiRouteMetadata> Put { get; }
        public Dictionary<string, OpenApiRouteMetadata> Delete { get; }
        public Dictionary<string, OpenApiRouteMetadata> Patch { get; }
        public Dictionary<string, OpenApiRouteMetadata> Options { get; }
        public Dictionary<string, OpenApiRouteMetadata> Head { get; }

        protected OpenApiModuleMetadata()
        {
            this["GET"] = Get = new Dictionary<string, OpenApiRouteMetadata>();
            this["POST"] = Post = new Dictionary<string, OpenApiRouteMetadata>();
            this["PUT"] = Put = new Dictionary<string, OpenApiRouteMetadata>();
            this["DELETE"] = Delete = new Dictionary<string, OpenApiRouteMetadata>();
            this["PATCH"] = Patch = new Dictionary<string, OpenApiRouteMetadata>();
            this["OPTIONS"] = Options = new Dictionary<string, OpenApiRouteMetadata>();
            this["HEAD"] = Head = new Dictionary<string, OpenApiRouteMetadata>();
        }

        public OpenApiRouteMetadata this[string method, string path]
        {
            get
            {
                Dictionary<string, OpenApiRouteMetadata> routes;
                TryGetValue(method.ToUpper(), out routes);

                if (routes == null) return null;

                OpenApiRouteMetadata routeMetadata;
                routes.TryGetValue(path, out routeMetadata);

                return routeMetadata;
            }
        }
    }
}