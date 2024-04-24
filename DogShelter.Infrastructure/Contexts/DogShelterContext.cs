using DogShelter.Domain.Entities;
using DogShelter.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.Contexts
{
    public class DogShelterContext : DbContext
    {
        public DogShelterContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DogConfig());
        }
    }
}
