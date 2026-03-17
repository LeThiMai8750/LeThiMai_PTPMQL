using Microsoft.EntityFrameworkCore;
using webmvc.Models;
using webmvc.Models.Entities;

namespace webmvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Student> Students { get; set; }
    }
}