using Catalog.Api.Utilities;

namespace Catalog.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbOptions>(configuration.GetSection("DatabaseSettings"));
        }
    }
}
