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
    public class ComptesComptablesConfiguration : EntityConfiguration<ComptesComptables>
    {
        public override void Configure(EntityTypeBuilder<ComptesComptables> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Numero).IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Intitule).IsRequired()
               .HasMaxLength(30);
            builder.Property(e => e.NatureCompteComptable).IsRequired()
               .HasMaxLength(2);

            builder.Property(e => e.Observation)
               .HasMaxLength(50);

            builder.HasIndex(e => new { e.SocieteId, e.Numero })
                .IsUnique();
            builder.HasIndex(e => new { e.SocieteId, e.Intitule })
               .IsUnique();

            builder
           .HasOne(s => s.Societe)
           .WithMany(g => g.ComptesComptabless)
           .HasForeignKey(s => s.SocieteId);
        }
    }
}
