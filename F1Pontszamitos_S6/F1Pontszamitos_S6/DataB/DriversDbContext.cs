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
                new Driver { Id = 7, Name = "Hamilton", ShortName = "HAM", Team_id = 10, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 50, Name = "Russel", ShortName = "RUS", Team_id = 10, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                
                new Driver { Id = 58, Name = "Leclerc", ShortName = "LEC", Team_id = 1, FinishingPositions = new List<int>(), FastestLapList = new List<int>(), isActive = true },
                new Driver { Id = 1, Name = "Sainz", ShortName = "SAI", Team_id = 1, FinishingPositions = new List<int>(), FastestLapList = new List<int>()  , isActive = false }, //FALSE
                
                new Driver { Id = 9, Name = "Verstappen", ShortName = "VER", Team_id = 2, FinishingPositions = new List<int>(), FastestLapList = new List<int>(), isActive = true },
                new Driver { Id = 14, Name = "Perez", ShortName = "PER", Team_id = 2, FinishingPositions = new List<int>(), FastestLapList = new List<int>(), isActive = false }, //FASLE

                new Driver { Id = 62, Name = "Albon", ShortName = "ALB", Team_id = 3, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 132, Name = "Sargeant", ShortName = "SAR", Team_id = 3, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                
                new Driver { Id = 3, Name = "Alonso", ShortName = "ALO", Team_id = 4, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 19, Name = "Stroll", ShortName = "STR", Team_id = 4, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = false },//FALSE
                
                new Driver { Id = 59, Name = "Gasly", ShortName = "GAS", Team_id = 5, FinishingPositions = new List<int>(), FastestLapList = new List<int>()  , isActive = true },
                new Driver { Id = 17, Name = "Ocon", ShortName = "OCO", Team_id = 5, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                
                new Driver { Id = 94, Name = "Tsunoda", ShortName = "TSU", Team_id = 6, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 2, Name = "Ricciardo", ShortName = "RIC", Team_id = 6, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },

                new Driver { Id = 10, Name = "Hulkenberg", ShortName = "HUL", Team_id = 7, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 11, Name = "Magnussen", ShortName = "MAG", Team_id = 7, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },

                new Driver { Id = 54, Name = "Norris", ShortName = "NOR", Team_id = 8, FinishingPositions = new List<int>(), FastestLapList = new List<int>(), isActive = true },
                new Driver { Id = 112, Name = "Piastri", ShortName = "PIA", Team_id = 8, FinishingPositions = new List<int>(), FastestLapList = new List<int>(), isActive = true },

                new Driver { Id = 80, Name = "Zhou", ShortName = "ZHO", Team_id = 9, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                new Driver { Id = 15, Name = "Bottas", ShortName = "BOT", Team_id = 9, FinishingPositions = new List<int>(), FastestLapList = new List<int>() , isActive = true },
                

                new Driver { Id = 120, Name = "Szarka", ShortName = "SZA", Team_id = 2, FinishingPositions = new(), FastestLapList = new(), isActive = true },
                new Driver { Id = 121, Name = "Bagosi", ShortName = "BAG", Team_id = 1, FinishingPositions = new(), FastestLapList = new(), isActive = true },
                new Driver { Id = 122, Name = "Berner", ShortName = "BER", Team_id = 4, FinishingPositions = new(), FastestLapList = new(), isActive = true }

                );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 10, Name = "Mercedes", BgColor = "#0da49f", Driver_ids = new List<int> { 7, 50 } },
                new Team { Id = 1, Name = "Ferrari", BgColor = "#fe0d0d", Driver_ids = new List<int> { 58, 1, 121 } },
                new Team { Id = 2, Name = "Red Bull", BgColor = "#021652", Driver_ids = new List<int> { 9, 14, 120 } },
                new Team { Id = 3, Name = "Williams", BgColor = "#0b3b7a", Driver_ids = new List<int> { 62, 132 } },
                new Team { Id = 4, Name = "Aston", BgColor = "#00533a", Driver_ids = new List<int> { 3, 19, 122 } },
                new Team { Id = 5, Name = "Alpine", BgColor = "#04111f", Driver_ids = new List<int> { 59, 17 } },
                new Team { Id = 6, Name = "Visa CashApp RB", BgColor = "#1534cc", Driver_ids = new List<int> { 94, 2 } },
                new Team { Id = 7, Name = "Haas", BgColor = "#ffffff", Driver_ids = new List<int> { 10, 11 } },
                new Team { Id = 8, Name = "McLaren", BgColor = "#ff6c0b", Driver_ids = new List<int> { 54, 112 } },
                new Team { Id = 9, Name = "Stake Sauber", BgColor = "#000000", Driver_ids = new List<int> { 80, 15 } }
                );

            modelBuilder.Entity<Race>().HasData(
                new Race { Id = 1, Name = "The Australian GP", ShortName = "AUS" },
                new Race { Id = 2, Name = "The Japanese GP", ShortName = "JPN" },
                new Race { Id = 3, Name = "The Chinese GP", ShortName = "CHN" },
                new Race { Id = 4, Name = "The Qatar GP", ShortName = "QTR" },
                new Race { Id = 5, Name = "The Bahrain GP", ShortName = "BHR" },
                new Race { Id = 6, Name = "The Saud Arabian GP", ShortName = "SAU" },
                new Race { Id = 7, Name = "The Miami GP", ShortName = "MMI" },
                new Race { Id = 8, Name = "The Canadian GP", ShortName = "CDN" },
                new Race { Id = 9, Name = "The Emilia Romagna GP", ShortName = "IML" },
                new Race { Id = 10, Name = "The Spanish GP", ShortName = "SPN" },
                new Race { Id = 11, Name = "The Austrian GP", ShortName = "AUT" },
                new Race { Id = 12, Name = "The Silverstone GP", ShortName = "GBR" },
                new Race { Id = 13, Name = "The Hungarian GP", ShortName = "HUN" },
                new Race { Id = 14, Name = "The Belgian GP", ShortName = "SPA" },
                new Race { Id = 15, Name = "The Dutch GP", ShortName = "NED" },
                new Race { Id = 16, Name = "The Italian GP", ShortName = "MZA" },
                new Race { Id = 17, Name = "The Portuguese GP", ShortName = "POR" },
                new Race { Id = 18, Name = "The Azerbajain GP", ShortName = "AZE" },
                new Race { Id = 19, Name = "Marina Bay GP", ShortName = "SGP" },
                new Race { Id = 20, Name = "Texas GP", ShortName = "TXS" },
                new Race { Id = 21, Name = "Mexican GP", ShortName = "MEX" },
                new Race { Id = 22, Name = "Sao Paulo GP", ShortName = "BRA" },
                new Race { Id = 23, Name = "Abu Dabhi GP", ShortName = "ABU" },
                new Race { Id = 24, Name = "The Las Vegas GP", ShortName = "VGS" }
                );
        }



        public DbSet<Driver> DriversTable { get; set; }

        public DbSet<Team> TeamsTable { get; set; }

        public DbSet<Race> RacesTable { get; set; }

    }
}
