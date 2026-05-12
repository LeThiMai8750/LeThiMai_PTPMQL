using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class suadevicetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goodreceiptdetails");

            migrationBuilder.DropColumn(
                name: "TotalStock",
                table: "Devicetypes");

            migrationBuilder.CreateTable(
                name: "Stockindts",
                columns: table => new
                {
                    StockindtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockinId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockindts", x => x.StockindtId);
                    table.ForeignKey(
                        name: "FK_Stockindts_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stockindts_Stockins_StockinId",
                        column: x => x.StockinId,
                        principalTable: "Stockins",
                        principalColumn: "StockinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stockindts_EquipmentId",
                table: "Stockindts",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockindts_StockinId",
                table: "Stockindts",
                column: "StockinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stockindts");

            migrationBuilder.AddColumn<int>(
                name: "TotalStock",
                table: "Devicetypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Goodreceiptdetails",
                columns: table => new
                {
                    GoodreceipdttId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockinId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goodreceiptdetails", x => x.GoodreceipdttId);
                    table.ForeignKey(
                        name: "FK_Goodreceiptdetails_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goodreceiptdetails_Stockins_StockinId",
                        column: x => x.StockinId,
                        principalTable: "Stockins",
                        principalColumn: "StockinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goodreceiptdetails_EquipmentId",
                table: "Goodreceiptdetails",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Goodreceiptdetails_StockinId",
                table: "Goodreceiptdetails",
                column: "StockinId");
        }
    }
}
