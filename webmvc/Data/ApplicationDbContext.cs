using Microsoft.EntityFrameworkCore;
using webmvc.Models;
namespace webmvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Person> Persons { get; set; } 
    }
}