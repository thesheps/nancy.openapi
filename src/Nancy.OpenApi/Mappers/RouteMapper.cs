using Nancy.OpenApi.Models;

namespace Nancy.OpenApi.Mappers
{
    public static class RouteMapper
    {
        public static Operation ToOperation(this PathMetadata routeMetadata)
        {
            return new Operation
            {
                Description = routeMetadata.Description,
                Summary = routeMetadata.Summary,
                Tags = routeMetadata.Tags,
                Produces = routeMetadata.Produces,
                Consumes = routeMetadata.Consumes,
                OperationId = routeMetadata.OperationId,
                Parameters = routeMetadata.Parameters
            };
        }
    }
}