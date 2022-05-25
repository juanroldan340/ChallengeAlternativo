using ChallengeAlternativo.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlternativo.Data
{
    public class GeographicIconsDbContext : DbContext
    {
        public GeographicIconsDbContext(DbContextOptions<GeographicIconsDbContext> options) : base(options) 
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<GeographicIcon> GeographicIcons { get; set; }
        public DbSet<City> Cities { get; set; }
        
    }
}
