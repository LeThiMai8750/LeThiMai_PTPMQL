using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webmvc.Migrations
{
    /// <inheritdoc />
    public partial class MultipleBuoi12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devicetypes",
                columns: table => new
                {
                    DevicetypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DevicetypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devicetypes", x => x.DevicetypeId);
                });

            migrationBuilder.CreateTable(
                name: "Stockins",
                columns: table => new
                {
                    StockinId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockins", x => x.StockinId);
                });

            migrationBuilder.CreateTable(
                name: "Stockouts",
                columns: table => new
                {
                    StockoutId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockouts", x => x.StockoutId);
                });

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    SuplierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuplierName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.SuplierId);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    DevicetypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Devicetypes_DevicetypeId",
                        column: x => x.DevicetypeId,
                        principalTable: "Devicetypes",
                        principalColumn: "DevicetypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goodreceiptdetails",
                columns: table => new
                {
                    GoodreceipdttId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockinId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Stockoutdts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockoutId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockoutdts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stockoutdts_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stockoutdts_Stockouts_StockoutId",
                        column: x => x.StockoutId,
                        principalTable: "Stockouts",
                        principalColumn: "StockoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DevicetypeId",
                table: "Equipments",
                column: "DevicetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Goodreceiptdetails_EquipmentId",
                table: "Goodreceiptdetails",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Goodreceiptdetails_StockinId",
                table: "Goodreceiptdetails",
                column: "StockinId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockoutdts_EquipmentId",
                table: "Stockoutdts",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockoutdts_StockoutId",
                table: "Stockoutdts",
                column: "StockoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goodreceiptdetails");

            migrationBuilder.DropTable(
                name: "Stockoutdts");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "Stockins");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Stockouts");

            migrationBuilder.DropTable(
                name: "Devicetypes");
        }
    }
}
