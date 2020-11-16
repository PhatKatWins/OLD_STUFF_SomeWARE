using Microsoft.EntityFrameworkCore.Migrations;

namespace SomeWARE.Migrations
{
    public partial class Availabilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockData",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StorageData",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    WarehouseCode = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Aisle = table.Column<string>(nullable: true),
                    Bin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_ItemId",
                table: "Availabilities",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.AddColumn<string>(
                name: "StockData",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageData",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
