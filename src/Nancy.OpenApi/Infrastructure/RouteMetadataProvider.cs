using System;
using System.Linq;
using Nancy.Routing;
using Nancy.TinyIoc;

namespace Nancy.OpenApi.Infrastructure
{
    /// <summary>
    /// Automatically resolves route metadata instances.
    /// </summary>
    public class RouteMetadataProvider : IRouteMetadataProvider
    {
        public RouteMetadataProvider(TinyIoCContainer container)
        {
            _container = container;
        }

        public Type GetMetadataType(INancyModule module, RouteDescription routeDescription)
        {
            return typeof(PathMetadata);
        }

        public object GetMetadata(INancyModule module, RouteDescription routeDescription)
        {
            var type = GetModuleMetadataType(module);
            var moduleMetadata = (ModuleMetadata)(type == null ? null : _container.Resolve(type));

            return moduleMetadata?[routeDescription.Method, routeDescription.Path];
        }

        private static Type GetModuleMetadataType(INancyModule module)
        {
            var metadataModuleName = module.GetType().Name.Replace("Module", "Metadata");
            var type = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(x => x.GetTypes())
                                .FirstOrDefault(x => x.Name == metadataModuleName);

            return typeof(ModuleMetadata).IsAssignableFrom(type) ? type : null;
        }

        private readonly TinyIoCContainer _container;
    }
}