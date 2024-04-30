using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.Contexts
{
    public class DogShelterContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedConfig());
            modelBuilder.ApplyConfiguration(new DogConfig());
        }
    }
}
