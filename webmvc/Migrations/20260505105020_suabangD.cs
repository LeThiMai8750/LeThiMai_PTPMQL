using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class suabangD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Devicetypes");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Devicetypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Devicetypes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Devicetypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
