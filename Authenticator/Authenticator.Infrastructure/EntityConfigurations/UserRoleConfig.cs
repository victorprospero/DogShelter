using Authenticator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authenticator.Infrastructure.EntityConfigurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new { e.Email, e.RoleId });
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.RoleId).IsRequired();

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Roles)
                .HasForeignKey(e => e.Email)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
