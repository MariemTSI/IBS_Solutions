using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tsi.Template.Infrastructure.Data;

namespace Tsi.Template.Data
{
    public class ApplicationContext: CoreContext
    {
        private readonly IConfiguration Configuration;
        public ApplicationContext(IConfiguration configuration) 
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
           .UseSqlServer(Configuration.GetConnectionString("Default"));
        //Enable this so entity framework will bring navigation variables when called!
        //.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ligne super importante => Pour la configuration des table de la plateforme
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
