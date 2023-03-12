using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServerAppDev_Final_Project.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    FishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.FishId);
                    table.ForeignKey(
                        name: "FK_Fish_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fish_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Pan Fish" },
                    { 2, "Bass" },
                    { 3, "Sucker Fish" },
                    { 4, "Catfish" },
                    { 5, "Trout" },
                    { 6, "Pike" },
                    { 7, "Salmon" },
                    { 8, "Drum" },
                    { 9, "Saltwater" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Pond" },
                    { 2, "Lake" },
                    { 3, "River" },
                    { 4, "Stream" },
                    { 5, "Ocean" }
                });

            migrationBuilder.InsertData(
                table: "Fish",
                columns: new[] { "FishId", "CategoryId", "Difficulty", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 2, 2, 1, "Largemouth Bass" },
                    { 4, 1, 1, 1, "Sunfish" },
                    { 5, 1, 1, 1, "Crappie" },
                    { 2, 2, 2, 2, "Smallmouth Bass" },
                    { 7, 3, 4, 2, "Lake Sturgeon" },
                    { 8, 4, 2, 2, "Channel Catfish" },
                    { 10, 8, 2, 2, "Sheephead" },
                    { 6, 3, 1, 3, "Sucker" },
                    { 9, 5, 4, 4, "Steelhead Trout" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fish_CategoryId",
                table: "Fish",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_LocationId",
                table: "Fish",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
