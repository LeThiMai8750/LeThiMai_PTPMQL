using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Sanphams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdh_Sanpham_SanphamMasanpham",
                table: "Chitietdh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sanpham",
                table: "Sanpham");

            migrationBuilder.RenameTable(
                name: "Sanpham",
                newName: "Sanphams");

            migrationBuilder.AlterColumn<string>(
                name: "SanphamMasanpham",
                table: "Chitietdh",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sanphams",
                table: "Sanphams",
                column: "Masanpham");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdh_Sanphams_SanphamMasanpham",
                table: "Chitietdh",
                column: "SanphamMasanpham",
                principalTable: "Sanphams",
                principalColumn: "Masanpham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdh_Sanphams_SanphamMasanpham",
                table: "Chitietdh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sanphams",
                table: "Sanphams");

            migrationBuilder.RenameTable(
                name: "Sanphams",
                newName: "Sanpham");

            migrationBuilder.AlterColumn<string>(
                name: "SanphamMasanpham",
                table: "Chitietdh",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sanpham",
                table: "Sanpham",
                column: "Masanpham");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdh_Sanpham_SanphamMasanpham",
                table: "Chitietdh",
                column: "SanphamMasanpham",
                principalTable: "Sanpham",
                principalColumn: "Masanpham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
