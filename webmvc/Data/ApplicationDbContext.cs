using Microsoft.EntityFrameworkCore;
using webmvc.Models;
using webmvc.Models.Buoi12;
using webmvc.Models.Buoi13;
using webmvc.Models.Entities;
using webmvc.Models.Demo;

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
        //Buoi 13
        public DbSet<Book> Books{ get; set; }
        // Demo
        public DbSet<Author> Author{ get; set; }
        public DbSet<Picture> Picture{ get; set; }
    }
}