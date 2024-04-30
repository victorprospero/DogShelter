using Authenticator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authenticator.Infrastructure.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Email);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Password).IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
