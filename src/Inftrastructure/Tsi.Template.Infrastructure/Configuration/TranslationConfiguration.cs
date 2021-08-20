using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class TranslationConfiguration : EntityConfiguration<Translation>
    {
        public override void Configure(EntityTypeBuilder<Translation> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Key).HasMaxLength(256);
            builder.Property(p => p.Value).HasMaxLength(4000);

            builder.HasIndex(x => new { x.Key, x.LanguageId });

            builder.HasOne<Language>()
                .WithMany()
                .HasForeignKey(p => p.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
