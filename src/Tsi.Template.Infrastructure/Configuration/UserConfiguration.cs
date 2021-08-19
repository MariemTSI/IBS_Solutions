using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Username).HasMaxLength(256);
            builder.Property(p => p.NormalizedUsername).HasMaxLength(256);
            builder.Property(p => p.Email).HasMaxLength(256);
            builder.Property(p => p.NormalizedEmail).HasMaxLength(256);
            builder.Property(p => p.PhoneNumber).HasMaxLength(15);
            builder.Property(p => p.LastIpAdress).HasMaxLength(15);

            builder.Property(p => p.LanguageId).IsRequired(false);
            

            builder.HasIndex(p => p.NormalizedUsername).IsUnique().HasFilter($" {nameof(User.NormalizedUsername)} IS NOT NULL ");
            builder.HasIndex(p => p.Username).IsUnique().HasFilter($" {nameof(User.Username)} IS NOT NULL ");
            builder.HasIndex(p => p.Email).IsUnique().HasFilter($" {nameof(User.Email)} IS NOT NULL ");
            builder.HasIndex(p => p.NormalizedEmail).IsUnique().HasFilter($" {nameof(User.NormalizedEmail)} IS NOT NULL ");
            builder.HasIndex(p => p.PhoneNumber).IsUnique();

            builder.HasOne<Language>()
                .WithMany()
                .HasForeignKey(p => p.LanguageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
