using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tsi.Template.Core;
using Tsi.Template.Core.Abstractions;

namespace Tsi.Template.Data.Installer
{
    public class DbContextInstaller : IInstaller
    {
        public int Order => 1;

        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>();

            EngineContext.Current.ContextType = typeof(ApplicationContext);
        }
    }
}
