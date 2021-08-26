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
    public class TiersConfiguration : EntityConfiguration<Tiers>
    {
        public override void Configure(EntityTypeBuilder<Tiers> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Type).IsRequired()
               .HasMaxLength(1);

            builder.Property(e => e.Code).IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.Intitule).IsRequired()
               .HasMaxLength(30);

            builder.Property(e => e.Adresse).IsRequired()
              .HasMaxLength(50);

            builder.Property(e => e.ComplementAdresse)
              .HasMaxLength(50);

            builder.Property(e => e.CP)
              .HasMaxLength(10);

            builder.Property(e => e.Ville)
              .HasMaxLength(30);

            builder.Property(e => e.Observation)
              .HasMaxLength(20);



            builder
         .HasOne(s => s.SecteursAcivites)
         .WithMany(g => g.Tierss)
         .HasForeignKey(s => s.SecteursActivitesId);

            builder
         .HasOne(s => s.Pays)
         .WithMany(g => g.Tierss)
         .HasForeignKey(s => s.PaysId);


        }
    }
}
