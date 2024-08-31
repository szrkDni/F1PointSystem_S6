using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1Pontszamitos_S6.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    Team_id = table.Column<int>(type: "INTEGER", nullable: true),
                    FinishingPositions = table.Column<string>(type: "TEXT", nullable: true),
                    FastestLapList = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RacesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Driver_ids = table.Column<string>(type: "TEXT", nullable: false),
                    BgColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DriversTable",
                columns: new[] { "Id", "FastestLapList", "FinishingPositions", "Name", "ShortName", "Team_id" },
                values: new object[,]
                {
                    { 1, "[1]", "[3]", "Verstappen", "VER", 1 },
                    { 2, "[1]", "[4]", "Norris", "NOR", 3 },
                    { 3, "[1]", "[1]", "Leclerc", "LEC", 2 },
                    { 4, "[1]", "[5]", "Piastri", "PIA", 3 },
                    { 5, "[0]", "[2]", "Sainz", "SAI", 2 },
                    { 6, "[0]", "[7]", "Hamilton", "HAM", 10 },
                    { 7, "[1]", "[6]", "Perez", "PER", 1 },
                    { 8, "[0]", "[5]", "Russel", "RUS", 10 },
                    { 9, "[0]", "[8]", "Alonso", "ALO", 5 },
                    { 10, "[0]", "[9]", "Stroll", "STR", 5 },
                    { 11, "[0]", "[10]", "Hulkenberg", "HUL", 8 },
                    { 12, "[0]", "[12]", "Tsunoda", "TSU", 6 },
                    { 13, "[0]", "[13]", "Ricciardo", "RIC", 6 },
                    { 14, "[0]", "[14]", "Gasly", "GAS", 9 },
                    { 15, "[0]", "[11]", "Magnussen", "MAG", 8 },
                    { 16, "[0]", "[16]", "Albon", "ALB", 7 },
                    { 17, "[0]", "[15]", "Ocon", "OCO", 9 },
                    { 18, "[0]", "[19]", "Zhou", "ZHO", 4 },
                    { 19, "[0]", "[17]", "Sargeant", "SAR", 7 },
                    { 20, "[0]", "[20]", "Bottas", "BOT", 4 }
                });

            migrationBuilder.InsertData(
                table: "RacesTable",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Bahrain GP", "BHR" },
                    { 2, "Las Vegas GP", "VEGAS" },
                    { 3, "Miami GP", "MIAMI" },
                    { 4, "Brazilian GP", "BRAZ" },
                    { 5, "Hungarian GP", "HUN" }
                });

            migrationBuilder.InsertData(
                table: "TeamsTable",
                columns: new[] { "Id", "BgColor", "Driver_ids", "Name" },
                values: new object[,]
                {
                    { 1, "#021652", "[1,7]", "Red Bull" },
                    { 2, "#fe0d0d", "[3,5]", "Ferrari" },
                    { 3, "#ff6c0b", "[2,4]", "McLaren" },
                    { 4, "#9f0d11", "[18,20]", "Alfa" },
                    { 5, "#00533a", "[9,10]", "Aston" },
                    { 6, "#0d3349", "[12,13]", "Tauri" },
                    { 7, "#0b3b7a", "[16,19]", "Williams" },
                    { 8, "#ffffff", "[11,15]", "Haas" },
                    { 9, "#04111f", "[14,17]", "Alpine" },
                    { 10, "#0da49f", "[6,8]", "Mercedes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversTable");

            migrationBuilder.DropTable(
                name: "RacesTable");

            migrationBuilder.DropTable(
                name: "TeamsTable");
        }
    }
}
