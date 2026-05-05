using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey_Donhangs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donhangs_Khachhangs_KhachhangMaKhachHang",
                table: "Donhangs");

            migrationBuilder.DropIndex(
                name: "IX_Donhangs_KhachhangMaKhachHang",
                table: "Donhangs");

            migrationBuilder.DropColumn(
                name: "KhachhangMaKhachHang",
                table: "Donhangs");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_MaKhachHang",
                table: "Donhangs",
                column: "MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_Donhangs_Khachhangs_MaKhachHang",
                table: "Donhangs",
                column: "MaKhachHang",
                principalTable: "Khachhangs",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donhangs_Khachhangs_MaKhachHang",
                table: "Donhangs");

            migrationBuilder.DropIndex(
                name: "IX_Donhangs_MaKhachHang",
                table: "Donhangs");

            migrationBuilder.AddColumn<string>(
                name: "KhachhangMaKhachHang",
                table: "Donhangs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_KhachhangMaKhachHang",
                table: "Donhangs",
                column: "KhachhangMaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_Donhangs_Khachhangs_KhachhangMaKhachHang",
                table: "Donhangs",
                column: "KhachhangMaKhachHang",
                principalTable: "Khachhangs",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
