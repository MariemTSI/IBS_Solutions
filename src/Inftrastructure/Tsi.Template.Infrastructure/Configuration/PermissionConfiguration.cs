using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class PermissionConfiguration: EntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.SystemName).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Name).HasMaxLength(256);

            builder.HasIndex(p => p.SystemName).IsUnique();
        }
    }
}
