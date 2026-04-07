using Microsoft.EntityFrameworkCore;
using webmvc.Models;

public class VidumauDbContext : DbContext
{
    // Hàm khởi tạo
    public VidumauDbContext(DbContextOptions<VidumauDbContext> options) : base(options) 
    {}
    // Các Dbset
    public DbSet<Vidumau> Vidumau { get; set; }
}