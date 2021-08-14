using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tsi.Template.Core.Entities;
using Tsi.Template.Infrastructure.Abstraction;

namespace Tsi.Template.Infrastructure.Configuration
{
    public class UserPasswordConfiguration : EntityConfiguration<UserPassword>
    {
        public override void Configure(EntityTypeBuilder<UserPassword> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Salt).HasMaxLength(256);
            builder.Property(p => p.Password).HasMaxLength(512);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(userPassword => userPassword.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
