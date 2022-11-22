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
    }
}
