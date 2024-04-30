using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.EntityConfigurations
{
    public class DogConfig : AuditEntityTypeConfiguration<Dog>
    {
        public override void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
            builder.Property(e => e.BreedId);
            builder.HasOne(e => e.Breed)
                .WithMany(e => e.Dogs)
                .HasForeignKey(e => e.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
