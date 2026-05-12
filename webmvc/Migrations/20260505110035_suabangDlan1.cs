using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class suabangDlan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalStock",
                table: "Devicetypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalStock",
                table: "Devicetypes");
        }
    }
}
