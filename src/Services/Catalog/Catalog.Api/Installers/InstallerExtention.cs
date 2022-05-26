namespace Catalog.Api.Installers
{
    public static class InstallerExtention
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();
            installers.ForEach(x => x.InstallServices(services, configuration));
        }
    }
}
