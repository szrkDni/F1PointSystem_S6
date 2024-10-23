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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    steamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team_id = table.Column<int>(type: "int", nullable: true),
                    FinishingPositions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FastestLapList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RacesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Driver_ids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BgColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DriversTable",
                columns: new[] { "Id", "FastestLapList", "FinishingPositions", "Name", "ShortName", "Team_id", "isActive", "steamName" },
                values: new object[,]
                {
                    { 1, "[]", "[]", "Sainz", "SAI", 1, true, "" },
                    { 2, "[]", "[]", "Ricciardo", "RIC", 6, true, "" },
                    { 3, "[]", "[]", "Alonso", "ALO", 4, true, "" },
                    { 7, "[]", "[]", "Hamilton", "HAM", 10, true, "" },
                    { 9, "[]", "[]", "Verstappen", "VER", 2, true, "" },
                    { 10, "[]", "[]", "Hulkenberg", "HUL", 7, true, "" },
                    { 11, "[]", "[]", "Magnussen", "MAG", 7, true, "" },
                    { 14, "[]", "[]", "Perez", "PER", 2, true, "" },
                    { 15, "[]", "[]", "Bottas", "BOT", 9, true, "" },
                    { 17, "[]", "[]", "Ocon", "OCO", 5, true, "" },
                    { 19, "[]", "[]", "Stroll", "STR", 4, true, "" },
                    { 50, "[]", "[]", "Russel", "RUS", 10, true, "" },
                    { 54, "[]", "[]", "Norris", "NOR", 8, true, "" },
                    { 58, "[]", "[]", "Leclerc", "LEC", 1, true, "" },
                    { 59, "[]", "[]", "Gasly", "GAS", 5, true, "" },
                    { 62, "[]", "[]", "Albon", "ALB", 3, true, "" },
                    { 80, "[]", "[]", "Zhou", "ZHO", 9, true, "" },
                    { 94, "[]", "[]", "Tsunoda", "TSU", 6, true, "" },
                    { 112, "[]", "[]", "Piastri", "PIA", 8, true, "" },
                    { 132, "[]", "[]", "Sargeant", "SAR", 3, true, "" }
                });

            migrationBuilder.InsertData(
                table: "RacesTable",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "The Bahrain GP", "BHR" },
                    { 2, "The Australian GP", "AUS" },
                    { 3, "The Japanese GP", "JPN" },
                    { 4, "The Chinese GP", "CHN" },
                    { 5, "The Qatar GP", "QTR" },
                    { 6, "The Saud Arabian GP", "SAU" },
                    { 7, "The Miami GP", "MMI" },
                    { 8, "The Canadian GP", "CDN" },
                    { 9, "The Emilia Romagna GP", "IML" },
                    { 10, "The Spanish GP", "SPN" },
                    { 11, "The Austrian GP", "AUT" },
                    { 12, "The Silverstone GP", "GBR" },
                    { 13, "The Hungarian GP", "HUN" },
                    { 14, "The Belgian GP", "SPA" },
                    { 15, "The Dutch GP", "NED" },
                    { 16, "The Italian GP", "MZA" },
                    { 17, "The Portuguese GP", "POR" },
                    { 18, "The Azerbajain GP", "AZE" },
                    { 19, "Marina Bay GP", "SGP" },
                    { 20, "Texas GP", "TXS" },
                    { 21, "Mexican GP", "MEX" },
                    { 22, "Sao Paulo GP", "BRA" },
                    { 23, "Abu Dabhi GP", "ABU" },
                    { 24, "The Las Vegas GP", "VGS" }
                });

            migrationBuilder.InsertData(
                table: "TeamsTable",
                columns: new[] { "Id", "BgColor", "Driver_ids", "Name" },
                values: new object[,]
                {
                    { 1, "#fe0d0d", "[58,1]", "Ferrari" },
                    { 2, "#021652", "[9,14]", "Red Bull" },
                    { 3, "#0b3b7a", "[62,132]", "Williams" },
                    { 4, "#00533a", "[3,19]", "Aston" },
                    { 5, "#04111f", "[59,17]", "Alpine" },
                    { 6, "#1534cc", "[94,2]", "Visa CashApp RB" },
                    { 7, "#ffffff", "[10,11]", "Haas" },
                    { 8, "#ff6c0b", "[54,112]", "McLaren" },
                    { 9, "#000000", "[80,15]", "Stake Sauber" },
                    { 10, "#0da49f", "[7,50]", "Mercedes" }
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
