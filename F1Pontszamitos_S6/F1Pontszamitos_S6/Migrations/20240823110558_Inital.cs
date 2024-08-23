using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1Pontszamitos_S6.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
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
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    Point = table.Column<int>(type: "INTEGER", nullable: false),
                    Team = table.Column<string>(type: "TEXT", nullable: true),
                    FinishingPositions = table.Column<string>(type: "TEXT", nullable: true),
                    FastestLapCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DriversTable",
                columns: new[] { "Id", "FastestLapCount", "FinishingPositions", "Name", "Point", "ShortName", "Team" },
                values: new object[,]
                {
                    { 1, 5, "[3,4,1,20]", "Verstappen", 277, "VER", "Red Bull" },
                    { 2, 2, "[1,2,3,4]", "Norris", 199, "NOR", "McLaren" },
                    { 3, 0, "[5,1,1,2]", "Leclerc", 177, "LEC", "Ferrari" },
                    { 4, 0, "[16,13,20,19]", "Piastri", 167, "PIA", "McLaren" },
                    { 5, 0, "[16,13,20,19]", "Sainz", 162, "SAI", "Ferrari" },
                    { 6, 0, "[16,13,20,19]", "Hamilton", 150, "HAM", "Mercedes" },
                    { 7, 0, "[16,13,20,19]", "Perez", 131, "PER", "Red Bull" },
                    { 8, 0, "[16,13,20,19]", "Russel", 116, "RUS", "Mercedes" },
                    { 9, 0, "[16,13,20,19]", "Alonso", 49, "ALO", "Aston" },
                    { 10, 0, "[16,13,20,19]", "Stroll", 24, "STR", "Aston" },
                    { 11, 0, "[16,13,20,19]", "Hulkenberg", 22, "HUL", "Haas" },
                    { 12, 0, "[16,13,20,19]", "Tsunoda", 22, "TSU", "Tauri" },
                    { 13, 0, "[16,13,20,19]", "Ricciardo", 11, "RIC", "Tauri" },
                    { 14, 0, "[16,13,20,19]", "Gasly", 6, "GAS", "Alpine" },
                    { 15, 0, "[16,13,20,19]", "Magnussen", 5, "MAG", "Haas" },
                    { 16, 0, "[16,13,20,19]", "Albon", 4, "ALB", "Williams" },
                    { 17, 0, "[16,13,20,19]", "Ocon", 4, "OCO", "Alpine" },
                    { 18, 0, "[16,13,20,19]", "Zhou", 0, "ZHO", "Alfa" },
                    { 19, 0, "[16,13,20,19]", "Sargeant", 0, "SAR", "Williams" },
                    { 20, 0, "[16,13,20,19]", "Bottas", 0, "BOT", "Alfa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversTable");
        }
    }
}
