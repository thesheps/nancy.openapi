using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Hosting.Aspnet;
using Nancy.OpenApi.Modules;
using Nancy.Responses;
using Nancy.TinyIoc;
using Nancy.ViewEngines;

namespace Nancy.OpenApi.Infrastructure
{
    public class OpenApiBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider => new AspNetRootPathProvider();

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            conventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("SwaggerUi/", viewName));

            foreach (var assembly in AppDomainAssemblyTypeScanner.Assemblies)
            {
                MapResourcesFromAssembly(conventions, assembly);
            }
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get { return NancyInternalConfiguration.WithOverrides(nic => nic.ViewLocationProvider = typeof(ResourceViewLocationProvider)); }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var assembly = typeof(OpenApiModule).Assembly;

            if (!ResourceViewLocationProvider.RootNamespaces.ContainsKey(assembly))
                ResourceViewLocationProvider.RootNamespaces.Add(assembly, "Nancy.OpenApi.SwaggerUi");
        }

        private static void MapResourcesFromAssembly(NancyConventions conventions, Assembly assembly)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            conventions.StaticContentsConventions.Add((ctx, p) =>
            {
                var filename = Path.GetFileName(ctx.Request.Path);
                var directoryName = Path.GetDirectoryName(ctx.Request.Path);
                var path = assembly.GetName().Name + directoryName?
                    .Replace(Path.DirectorySeparatorChar, '.')
                    .Replace("-", "_")
                    .TrimEnd('.');

                var name = string.Concat(path, ".", filename);

                return resourceNames.Any(r => r.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    ? new EmbeddedFileResponse(assembly, path, filename)
                    : null;
            });
        }
    }
}