using System;
using System.Collections.Generic;
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

            if (type == null) return null;

            ModuleMetadata metadata;
            if (MetadataItems.TryGetValue(type, out metadata))
                return metadata[routeDescription.Method, routeDescription.Path];

            metadata = (ModuleMetadata)(_container.Resolve(type));
            MetadataItems.Add(type, metadata);

            return metadata?[routeDescription.Method, routeDescription.Path];
        }

        private static Type GetModuleMetadataType(INancyModule module)
        {
            var metadataName = module.GetType().Name.Replace("Module", "Metadata");

            Type type;
            if (ModuleTypes.TryGetValue(metadataName, out type)) return type;

            type = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .FirstOrDefault(x => x.Name == metadataName);

            ModuleTypes.Add(metadataName, type);

            return typeof(ModuleMetadata).IsAssignableFrom(type) ? type : null;
        }

        private static readonly Dictionary<string, Type> ModuleTypes = new Dictionary<string, Type>(); 
        private static readonly Dictionary<Type, ModuleMetadata> MetadataItems = new Dictionary<Type, ModuleMetadata>();
        private readonly TinyIoCContainer _container;
    }
}