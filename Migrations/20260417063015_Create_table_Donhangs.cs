using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Donhangs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdh_Donhang_DonhangMadonhang",
                table: "Chitietdh");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdh_Sanphams_SanphamMasanpham",
                table: "Chitietdh");

            migrationBuilder.DropForeignKey(
                name: "FK_Donhang_Khachhangs_KhachhangMaKhachHang",
                table: "Donhang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donhang",
                table: "Donhang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietdh",
                table: "Chitietdh");

            migrationBuilder.RenameTable(
                name: "Donhang",
                newName: "Donhangs");

            migrationBuilder.RenameTable(
                name: "Chitietdh",
                newName: "Chitietdhs");

            migrationBuilder.RenameIndex(
                name: "IX_Donhang_KhachhangMaKhachHang",
                table: "Donhangs",
                newName: "IX_Donhangs_KhachhangMaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietdh_SanphamMasanpham",
                table: "Chitietdhs",
                newName: "IX_Chitietdhs_SanphamMasanpham");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietdh_DonhangMadonhang",
                table: "Chitietdhs",
                newName: "IX_Chitietdhs_DonhangMadonhang");

            migrationBuilder.AlterColumn<string>(
                name: "KhachhangMaKhachHang",
                table: "Donhangs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SanphamMasanpham",
                table: "Chitietdhs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonhangMadonhang",
                table: "Chitietdhs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donhangs",
                table: "Donhangs",
                column: "Madonhang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietdhs",
                table: "Chitietdhs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdhs_Donhangs_DonhangMadonhang",
                table: "Chitietdhs",
                column: "DonhangMadonhang",
                principalTable: "Donhangs",
                principalColumn: "Madonhang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdhs_Sanphams_SanphamMasanpham",
                table: "Chitietdhs",
                column: "SanphamMasanpham",
                principalTable: "Sanphams",
                principalColumn: "Masanpham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donhangs_Khachhangs_KhachhangMaKhachHang",
                table: "Donhangs",
                column: "KhachhangMaKhachHang",
                principalTable: "Khachhangs",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdhs_Donhangs_DonhangMadonhang",
                table: "Chitietdhs");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdhs_Sanphams_SanphamMasanpham",
                table: "Chitietdhs");

            migrationBuilder.DropForeignKey(
                name: "FK_Donhangs_Khachhangs_KhachhangMaKhachHang",
                table: "Donhangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donhangs",
                table: "Donhangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietdhs",
                table: "Chitietdhs");

            migrationBuilder.RenameTable(
                name: "Donhangs",
                newName: "Donhang");

            migrationBuilder.RenameTable(
                name: "Chitietdhs",
                newName: "Chitietdh");

            migrationBuilder.RenameIndex(
                name: "IX_Donhangs_KhachhangMaKhachHang",
                table: "Donhang",
                newName: "IX_Donhang_KhachhangMaKhachHang");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietdhs_SanphamMasanpham",
                table: "Chitietdh",
                newName: "IX_Chitietdh_SanphamMasanpham");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietdhs_DonhangMadonhang",
                table: "Chitietdh",
                newName: "IX_Chitietdh_DonhangMadonhang");

            migrationBuilder.AlterColumn<string>(
                name: "KhachhangMaKhachHang",
                table: "Donhang",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "SanphamMasanpham",
                table: "Chitietdh",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DonhangMadonhang",
                table: "Chitietdh",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donhang",
                table: "Donhang",
                column: "Madonhang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietdh",
                table: "Chitietdh",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdh_Donhang_DonhangMadonhang",
                table: "Chitietdh",
                column: "DonhangMadonhang",
                principalTable: "Donhang",
                principalColumn: "Madonhang");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdh_Sanphams_SanphamMasanpham",
                table: "Chitietdh",
                column: "SanphamMasanpham",
                principalTable: "Sanphams",
                principalColumn: "Masanpham");

            migrationBuilder.AddForeignKey(
                name: "FK_Donhang_Khachhangs_KhachhangMaKhachHang",
                table: "Donhang",
                column: "KhachhangMaKhachHang",
                principalTable: "Khachhangs",
                principalColumn: "MaKhachHang");
        }
    }
}
