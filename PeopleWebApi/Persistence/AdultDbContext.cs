using Microsoft.EntityFrameworkCore;
using PeopleWebApi.Models;

namespace PeopleWebApi.Persistence
{
    public class AdultDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }
    }
}