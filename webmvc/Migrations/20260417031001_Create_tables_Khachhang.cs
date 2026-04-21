using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class Create_tables_Khachhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    Masanpham = table.Column<string>(type: "TEXT", nullable: false),
                    TenSanPham = table.Column<string>(type: "TEXT", nullable: false),
                    Soluongton = table.Column<int>(type: "INTEGER", nullable: false),
                    Gia = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.Masanpham);
                });

            migrationBuilder.CreateTable(
                name: "Donhang",
                columns: table => new
                {
                    Madonhang = table.Column<string>(type: "TEXT", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    KhachhangMaKhachHang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhang", x => x.Madonhang);
                    table.ForeignKey(
                        name: "FK_Donhang_Khachhangs_KhachhangMaKhachHang",
                        column: x => x.KhachhangMaKhachHang,
                        principalTable: "Khachhangs",
                        principalColumn: "MaKhachHang");
                });

            migrationBuilder.CreateTable(
                name: "Chitietdh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Madonhang = table.Column<string>(type: "TEXT", nullable: false),
                    Masanpham = table.Column<string>(type: "TEXT", nullable: false),
                    Soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    DonGia = table.Column<decimal>(type: "TEXT", nullable: false),
                    DonhangMadonhang = table.Column<string>(type: "TEXT", nullable: true),
                    SanphamMasanpham = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chitietdh_Donhang_DonhangMadonhang",
                        column: x => x.DonhangMadonhang,
                        principalTable: "Donhang",
                        principalColumn: "Madonhang");
                    table.ForeignKey(
                        name: "FK_Chitietdh_Sanpham_SanphamMasanpham",
                        column: x => x.SanphamMasanpham,
                        principalTable: "Sanpham",
                        principalColumn: "Masanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdh_DonhangMadonhang",
                table: "Chitietdh",
                column: "DonhangMadonhang");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdh_SanphamMasanpham",
                table: "Chitietdh",
                column: "SanphamMasanpham");

            migrationBuilder.CreateIndex(
                name: "IX_Donhang_KhachhangMaKhachHang",
                table: "Donhang",
                column: "KhachhangMaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdh");

            migrationBuilder.DropTable(
                name: "Donhang");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "Khachhangs");
        }
    }
}
