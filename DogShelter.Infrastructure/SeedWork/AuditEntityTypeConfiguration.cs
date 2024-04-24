using DogShelter.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogShelter.Infrastructure.SeedWork
{
    public class AuditEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedOn)
                .HasField("CREATEDON")
                .IsRequired();

            builder.Property(e => e.LastUpdated)
                .HasField("LASTUPDATED");
        }
    }
}