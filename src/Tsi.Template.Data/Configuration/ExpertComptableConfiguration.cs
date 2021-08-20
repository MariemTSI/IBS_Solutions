using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Data.Configuration
{
    public class ExpertComptableConfiguration : EntityConfiguration<ExpertComptable>
    {
        public override void Configure(EntityTypeBuilder<ExpertComptable> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.Nom).IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Adresse).IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ComplementAdresse)
                .HasMaxLength(50);

            builder.Property(e => e.CP).IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Ville).IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Observation)
                .HasMaxLength(50);


            builder.HasIndex(e => e.Code).IsUnique();
            builder.HasIndex(e => e.Nom).IsUnique();


            builder
            .HasOne(s => s.Pays)
            .WithMany(g => g.ExpertComptables)
            .HasForeignKey(s => s.PaysId);
        }
    }
}
