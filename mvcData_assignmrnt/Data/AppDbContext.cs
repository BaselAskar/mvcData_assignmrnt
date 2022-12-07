using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Models.DTOs;

namespace mvcData_assignmrnt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(c => c.HasIndex(c => c.Name).IsUnique());

            modelBuilder.Entity<City>(c => c.HasIndex(city => city.Name).IsUnique());

            modelBuilder.Entity<Language>(lang => lang.HasIndex(l => l.Name).IsUnique());
        }

        public DbSet<mvcData_assignmrnt.Models.DTOs.UpdatePersonView> UpdatePersonView { get; set; }
    }
}
