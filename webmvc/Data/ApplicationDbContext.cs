using Microsoft.EntityFrameworkCore;
using webmvc.Models;
using webmvc.Models.Buoi12;
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
        // Buoi12
        public DbSet<Suplier> Supliers{ get; set; }
        public DbSet<Devicetype> Devicetypes{ get; set; }
        public DbSet<Equipment> Equipments{ get; set; }
        public DbSet<Stockin> Stockins{ get; set; }
        public DbSet<Stockindt> Stockindts{ get; set; }
        public DbSet<Stockout> Stockouts{ get; set; }
        public DbSet<Stockoutdt> Stockoutdts{ get; set; }
    }
}