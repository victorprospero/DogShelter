using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.EntityConfigurations
{
    public class DogConfig : AuditEntityTypeConfiguration<Dog>
    {
        public override void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(64);
            builder.Property(e => e.Breed).HasMaxLength(64);
            builder.Property(e => e.Temperament).HasMaxLength(64);
            builder.Property(e => e.MinHeight).IsRequired();
            builder.Property(e => e.MinHeight).IsRequired();
            base.Configure(builder);
        }
    }
}
