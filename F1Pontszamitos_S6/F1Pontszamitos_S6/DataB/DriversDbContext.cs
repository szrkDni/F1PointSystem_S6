using F1Pontszamitos_S6.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            //modelBuilder.Entity<Driver>().Ignore(y => y.steamName);
            modelBuilder.Entity<Driver>().Ignore(y => y.lapsByRaces);

            modelBuilder.Entity<Driver>().HasData(
                new Driver ( 7,    "Hamilton",      "HAM", 10, true ),
                new Driver ( 50,   "Russel",        "RUS", 10, true ),
                                                                                                                 
                new Driver ( 58,   "Leclerc",       "LEC", 1,  true ),
                new Driver ( 1,   "Sainz",         "SAI", 1,  true ), 
                                                                                                                 
                new Driver ( 9,   "Verstappen",    "VER", 2,  true ),
                new Driver ( 14,  "Perez",         "PER", 2,  true ), 
                                                                                                                 
                new Driver ( 62,  "Albon",         "ALB", 3,  true ),
                new Driver ( 132, "Sargeant",      "SAR", 3,  true ),
                                                                                                                 
                new Driver ( 3,   "Alonso",        "ALO", 4,  true ),
                new Driver ( 19,  "Stroll",        "STR", 4,  true ),
                                                                                                                 
                new Driver ( 59,  "Gasly",         "GAS", 5,  true ),
                new Driver ( 17,  "Ocon",          "OCO", 5,  true ),
                                                                                                                 
                new Driver ( 94,  "Tsunoda",       "TSU", 6,  true ),
                new Driver ( 2,   "Ricciardo",     "RIC", 6,  true ),
                                                                                                                 
                new Driver ( 10,  "Hulkenberg",    "HUL", 7,  true ),
                new Driver ( 11,  "Magnussen",     "MAG", 7,  true ),
                                                                                                                 
                new Driver ( 54,  "Norris",        "NOR", 8,  true ),
                new Driver ( 112, "Piastri",       "PIA", 8,  true ),
                                                                                                                 
                new Driver ( 80,  "Zhou",          "ZHO", 9,  true ),
                new Driver ( 15,  "Bottas",        "BOT", 9,  true )


                //new Driver ( 170,"Dummy",          "Dum", 19, false )
                //new Driver { Id = 171, Name = "Bagosi", ShortName = "BAG", Team_id = 1, FinishingPositions = new(), FastestLapList = new(), isActive = true },
                //new Driver { Id = 172, Name = "Berner", ShortName = "BER", Team_id = 4, FinishingPositions = new(), FastestLapList = new(), isActive = true }
                
                );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 10, Name = "Mercedes",          BgColor = "#0da49f",    Driver_ids = new List<int> { 7, 50   }    },
                new Team { Id = 1,  Name = "Ferrari",           BgColor = "#fe0d0d",    Driver_ids = new List<int> { 58, 1   }    },
                new Team { Id = 2,  Name = "Red Bull",          BgColor = "#021652",    Driver_ids = new List<int> { 9, 14   }    },
                new Team { Id = 3,  Name = "Williams",          BgColor = "#0b3b7a",    Driver_ids = new List<int> { 62, 132 }    },
                new Team { Id = 4,  Name = "Aston",             BgColor = "#00533a",    Driver_ids = new List<int> { 3, 19   }    },
                new Team { Id = 5,  Name = "Alpine",            BgColor = "#04111f",    Driver_ids = new List<int> { 59, 17  }    },
                new Team { Id = 6,  Name = "Visa CashApp RB",   BgColor = "#1534cc",    Driver_ids = new List<int> { 94, 2   }    },
                new Team { Id = 7,  Name = "Haas",              BgColor = "#ffffff",    Driver_ids = new List<int> { 10, 11  }    },
                new Team { Id = 8,  Name = "McLaren",           BgColor = "#ff6c0b",    Driver_ids = new List<int> { 54, 112 }    },
                new Team { Id = 9,  Name = "Stake Sauber",      BgColor = "#000000",    Driver_ids = new List<int> { 80, 15  }    }
                );


            modelBuilder.Entity<Race>().HasData(
                new Race ("The Bahrain GP",          "BHR"),
                new Race ("The Australian GP",      "AUS" ),
                new Race ("The Japanese GP",        "JPN" ),
                new Race ("The Chinese GP",         "CHN" ),
                new Race ("The Qatar GP",           "QTR" ),
                new Race ("The Saud Arabian GP",    "SAU" ),
                new Race ("The Miami GP",           "MMI" ),
                new Race ("The Canadian GP",        "CDN" ),
                new Race ("The Emilia Romagna GP",  "IML" ),
                new Race ("The Spanish GP",         "SPN" ),
                new Race ("The Austrian GP",        "AUT" ),
                new Race ("The Silverstone GP",     "GBR" ),
                new Race ("The Hungarian GP",       "HUN" ),
                new Race ("The Belgian GP",         "SPA" ),
                new Race ("The Dutch GP",           "NED" ),
                new Race ("The Italian GP",         "MZA" ),
                new Race ("The Portuguese GP",      "POR" ),
                new Race ("The Azerbajain GP",      "AZE" ),
                new Race ("Marina Bay GP",          "SGP" ),
                new Race ("Texas GP",               "TXS" ),
                new Race ("Mexican GP",             "MEX" ),
                new Race ("Sao Paulo GP",           "BRA" ),
                new Race ("Abu Dabhi GP",           "ABU" ),
                new Race ("The Las Vegas GP",       "VGS" )
                );
        }



        public DbSet<Driver> DriversTable { get; set; }

        public DbSet<Team> TeamsTable { get; set; }

        public DbSet<Race> RacesTable { get; set; }

    }
}
