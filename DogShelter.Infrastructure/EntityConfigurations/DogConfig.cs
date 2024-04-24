using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.EntityConfigurations
{
    public class DogConfig : AuditEntityTypeConfiguration<Dog>
    {
        public override void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasValueGenerator<InMemoryIntegerValueGenerator<ulong>>()
                .HasField("ID");

            builder.Property(e => e.Name)
                .HasField("NAME")
                .HasMaxLength(64);

            builder.Property(e => e.Breed)
                .HasField("BREED")
                .HasMaxLength(64);

            builder.Property(e => e.Temperament)
                .HasField("TEMPERAMENT")
                .HasMaxLength(64);

            builder.Property(e => e.MinHeight)
                .HasField("MINHEIGHT")
                .IsRequired();

            builder.Property(e => e.MinHeight)
                .HasField("MAXHEIGHT")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
