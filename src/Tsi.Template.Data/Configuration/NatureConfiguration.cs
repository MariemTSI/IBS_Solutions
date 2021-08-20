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
    public class NatureConfiguration : EntityConfiguration<Nature>
    {
        public override void Configure(EntityTypeBuilder<Nature> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.Nom).IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.CodeSurDeclaration).IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Observation)
                .HasMaxLength(50);



            builder.HasIndex(e => e.Code).IsUnique();
            builder.HasIndex(e => e.Nom).IsUnique();

        }
    }
}
