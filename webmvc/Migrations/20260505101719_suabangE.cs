using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class suabangE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipmentName",
                table: "Equipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentName",
                table: "Equipments");
        }
    }
}
