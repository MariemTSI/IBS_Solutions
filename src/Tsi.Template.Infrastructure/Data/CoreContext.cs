using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Tsi.Template.Infrastructure.Data
{
    public class CoreContext : DbContext
    {  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreContext).Assembly);
        }


        public Task<int> CommitAsync()
        {
            return SaveChangesAsync();
        }
    }
}
