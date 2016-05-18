using System;
using Nancy.Routing;

namespace Nancy.OpenApi.WebHost
{
    public class RouteMetadataProvider : IRouteMetadataProvider
    {
        public Type GetMetadataType(INancyModule module, RouteDescription routeDescription)
        {
            throw new NotImplementedException();
        }

        public object GetMetadata(INancyModule module, RouteDescription routeDescription)
        {
            throw new NotImplementedException();
        }
    }
}