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
        public DbSet<Faculty> Faculties{ get; set; }
        //buoi thuc hanh so 9
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Khachhang> Khachhangs{ get; set; }
        public DbSet<Sanpham> Sanphams{ get; set; }
        public DbSet<Donhang> Donhangs{ get; set; }
        public DbSet<Chitietdh> Chitietdhs{ get; set; }
    }
}