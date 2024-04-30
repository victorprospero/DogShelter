using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.EntityConfigurations
{
    public class BreedConfig : AuditEntityTypeConfiguration<Breed>
    {
        public override void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
            builder.Property(e => e.Temperament).HasMaxLength(64);
            builder.Property(e => e.MinHeight).IsRequired();
            builder.Property(e => e.MinHeight).IsRequired();

            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
