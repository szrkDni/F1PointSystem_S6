using F1Pontszamitos_S6.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace F1Pontszamitos_S6.DataB
{
    public class DriversDbContext : DbContext
    {
        public DriversDbContext(DbContextOptions<DriversDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>().HasData(
                new Driver { Id = 1, Name = "Verstappen", ShortName = "VER", Team = "Red Bull", Point = 277, FastestLapCount = 5, FinishingPositions = new List<int> { 3, 4, 1, 20 } },
                new Driver { Id = 2, Name = "Norris", ShortName = "NOR", Team = "McLaren", Point = 199, FastestLapCount = 2, FinishingPositions = new List<int> { 1, 2, 3, 4 } },
                new Driver { Id = 3, Name = "Leclerc", ShortName = "LEC", Team = "Ferrari", Point = 177, FastestLapCount = 0, FinishingPositions = new List<int> { 5, 1, 1, 2 } },
                new Driver { Id = 4, Name = "Piastri", ShortName = "PIA", Team = "McLaren", Point = 167, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 5, Name = "Sainz", ShortName = "SAI", Team = "Ferrari", Point = 162, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 6, Name = "Hamilton", ShortName = "HAM", Team = "Mercedes", Point = 150, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 7, Name = "Perez", ShortName = "PER", Team = "Red Bull", Point = 131, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 8, Name = "Russel", ShortName = "RUS", Team = "Mercedes", Point = 116, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 9, Name = "Alonso", ShortName = "ALO", Team = "Aston", Point = 49, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 10, Name = "Stroll", ShortName = "STR", Team = "Aston", Point = 24, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 11, Name = "Hulkenberg", ShortName = "HUL", Team = "Haas", Point = 22, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 12, Name = "Tsunoda", ShortName = "TSU", Team = "Tauri", Point = 22, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 13, Name = "Ricciardo", ShortName = "RIC", Team = "Tauri", Point = 11, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 14, Name = "Gasly", ShortName = "GAS", Team = "Alpine", Point = 6, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 15, Name = "Magnussen", ShortName = "MAG", Team = "Haas", Point = 5, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 16, Name = "Albon", ShortName = "ALB", Team = "Williams", Point = 4, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 17, Name = "Ocon", ShortName = "OCO", Team = "Alpine", Point = 4, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 18, Name = "Zhou", ShortName = "ZHO", Team = "Alfa", Point = 0, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 19, Name = "Sargeant", ShortName = "SAR", Team = "Williams", Point = 0, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } },
                new Driver { Id = 20, Name = "Bottas", ShortName = "BOT", Team = "Alfa", Point = 0, FastestLapCount = 0, FinishingPositions = new List<int> { 16, 13, 20, 19 } }
                );
        }

        public DbSet<Driver> DriversTable { get; set; }

    }
}
