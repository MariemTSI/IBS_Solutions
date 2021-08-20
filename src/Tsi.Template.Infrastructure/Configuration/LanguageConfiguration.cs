using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class LanguageConfiguration : EntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.LanguageCulture).HasMaxLength(10);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.UniqueSeoCode).HasMaxLength(5);
        }
    }
}
