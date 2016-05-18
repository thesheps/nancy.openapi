using Nancy.OpenApi.Infrastructure;
using Nancy.OpenApi.Models;

namespace Nancy.OpenApi.Mappers
{
    public static class RouteMapper
    {
        public static OperationObject ToOperationObject(this PathMetadata routeMetadata)
        {
            return new OperationObject
            {
                Description = routeMetadata.Description,
                Summary = routeMetadata.Summary,
                Tags = routeMetadata.Tags,
                Produces = routeMetadata.Produces,
                Consumes = routeMetadata.Consumes,
                OperationId = routeMetadata.OperationId
            };
        }
    }
}