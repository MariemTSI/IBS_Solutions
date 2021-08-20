using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class SettingConfiguration : EntityConfiguration<Setting>
    {
        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).HasMaxLength(256).IsRequired(); 
            builder.Property(p => p.Name).HasMaxLength(6000).IsRequired(); 
        }
    }
}
