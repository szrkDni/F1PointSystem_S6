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
                new Driver { Id = 1, Name = "Verstappen", ShortName = "VER", Team_id = 1, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 7, Name = "Perez", ShortName = "PER", Team_id = 1, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 2, Name = "Norris", ShortName = "NOR", Team_id = 3, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 4, Name = "Piastri", ShortName = "PIA", Team_id = 3, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 3, Name = "Leclerc", ShortName = "LEC", Team_id = 2, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 5, Name = "Sainz", ShortName = "SAI", Team_id = 2, FinishingPositions = new List<int>(), FastestLapList = new List<int>()  },

                new Driver { Id = 6, Name = "Hamilton", ShortName = "HAM", Team_id = 10, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 8, Name = "Russel", ShortName = "RUS", Team_id = 10, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 9, Name = "Alonso", ShortName = "ALO", Team_id = 5, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 10, Name = "Stroll", ShortName = "STR", Team_id = 5, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 11, Name = "Hulkenberg", ShortName = "HUL", Team_id = 8, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 15, Name = "Magnussen", ShortName = "MAG", Team_id = 8, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 12, Name = "Tsunoda", ShortName = "TSU", Team_id = 6, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 13, Name = "Ricciardo", ShortName = "RIC", Team_id = 6, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 14, Name = "Gasly", ShortName = "GAS", Team_id = 9, FinishingPositions = new List<int>(), FastestLapList = new List<int>()  },
                new Driver { Id = 17, Name = "Ocon", ShortName = "OCO", Team_id = 9, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 16, Name = "Albon", ShortName = "ALB", Team_id = 7, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 19, Name = "Sargeant", ShortName = "SAR", Team_id = 7, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },

                new Driver { Id = 18, Name = "Zhou", ShortName = "ZHO", Team_id = 4, FinishingPositions = new List<int>(), FastestLapList = new List<int>() },
                new Driver { Id = 20, Name = "Bottas", ShortName = "BOT", Team_id = 4, FinishingPositions = new List<int>(), FastestLapList = new List<int>() }
                );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Red Bull", BgColor = "#021652", Driver_ids = new List<int> { 1, 7 } },
                new Team { Id = 2, Name = "Ferrari", BgColor = "#fe0d0d", Driver_ids = new List<int> { 3, 5 } },
                new Team { Id = 3, Name = "McLaren", BgColor = "#ff6c0b", Driver_ids = new List<int> { 2, 4 } },
                new Team { Id = 4, Name = "Alfa", BgColor = "#9f0d11", Driver_ids = new List<int> { 18, 20 } },
                new Team { Id = 5, Name = "Aston", BgColor = "#00533a", Driver_ids = new List<int> { 9, 10 } },
                new Team { Id = 6, Name = "Tauri", BgColor = "#0d3349", Driver_ids = new List<int> { 12, 13 } },
                new Team { Id = 7, Name = "Williams", BgColor = "#0b3b7a", Driver_ids = new List<int> { 16, 19 } },
                new Team { Id = 8, Name = "Haas", BgColor = "#ffffff", Driver_ids = new List<int> { 11, 15 } },
                new Team { Id = 9, Name = "Alpine", BgColor = "#04111f", Driver_ids = new List<int> { 14, 17 } },
                new Team { Id = 10, Name = "Mercedes", BgColor = "#0da49f", Driver_ids = new List<int> { 6, 8 } }
                );

            modelBuilder.Entity<Race>().HasData(
                new Race { Id = 1, Name = "Bahrain GP", ShortName = "BHR" },
                new Race { Id = 2, Name = "Las Vegas GP", ShortName = "VEGAS" },
                new Race { Id = 3, Name = "Miami GP", ShortName = "MIAMI" },
                new Race { Id = 4, Name = "Brazilian GP", ShortName = "BRAZ" },
                new Race { Id = 5, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 6, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 7, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 8, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 9, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 10, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 11, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 12, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 13, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 14, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 15, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 16, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 17, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 18, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 19, Name = "Hungarian GP", ShortName = "HUN" },
                new Race { Id = 20, Name = "Hungarian GP", ShortName = "HUN" }
                );
        }



        public DbSet<Driver> DriversTable { get; set; }

        public DbSet<Team> TeamsTable { get; set; }

        public DbSet<Race> RacesTable { get; set; }

    }
}
