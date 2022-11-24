using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person>? People { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Country>? Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(c => c.HasIndex(c => c.Name).IsUnique());

            modelBuilder.Entity<City>(c => c.HasIndex(city => city.Name).IsUnique());
        }
    }
}
