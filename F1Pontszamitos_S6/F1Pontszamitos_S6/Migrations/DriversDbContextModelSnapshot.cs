﻿// <auto-generated />
using System;
using F1Pontszamitos_S6.DataB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace F1Pontszamitos_S6.Migrations
{
    [DbContext(typeof(DriversDbContext))]
    partial class DriversDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("F1Pontszamitos_S6.Shared.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FastestLapList")
                        .HasColumnType("TEXT");

                    b.Property<string>("FinishingPositions")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Team_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DriversTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FastestLapList = "[1]",
                            FinishingPositions = "[3]",
                            Name = "Verstappen",
                            ShortName = "VER",
                            Team_id = 1
                        },
                        new
                        {
                            Id = 7,
                            FastestLapList = "[1]",
                            FinishingPositions = "[6]",
                            Name = "Perez",
                            ShortName = "PER",
                            Team_id = 1
                        },
                        new
                        {
                            Id = 2,
                            FastestLapList = "[1]",
                            FinishingPositions = "[4]",
                            Name = "Norris",
                            ShortName = "NOR",
                            Team_id = 3
                        },
                        new
                        {
                            Id = 4,
                            FastestLapList = "[1]",
                            FinishingPositions = "[5]",
                            Name = "Piastri",
                            ShortName = "PIA",
                            Team_id = 3
                        },
                        new
                        {
                            Id = 3,
                            FastestLapList = "[1]",
                            FinishingPositions = "[1]",
                            Name = "Leclerc",
                            ShortName = "LEC",
                            Team_id = 2
                        },
                        new
                        {
                            Id = 5,
                            FastestLapList = "[0]",
                            FinishingPositions = "[2]",
                            Name = "Sainz",
                            ShortName = "SAI",
                            Team_id = 2
                        },
                        new
                        {
                            Id = 6,
                            FastestLapList = "[0]",
                            FinishingPositions = "[7]",
                            Name = "Hamilton",
                            ShortName = "HAM",
                            Team_id = 10
                        },
                        new
                        {
                            Id = 8,
                            FastestLapList = "[0]",
                            FinishingPositions = "[5]",
                            Name = "Russel",
                            ShortName = "RUS",
                            Team_id = 10
                        },
                        new
                        {
                            Id = 9,
                            FastestLapList = "[0]",
                            FinishingPositions = "[8]",
                            Name = "Alonso",
                            ShortName = "ALO",
                            Team_id = 5
                        },
                        new
                        {
                            Id = 10,
                            FastestLapList = "[0]",
                            FinishingPositions = "[9]",
                            Name = "Stroll",
                            ShortName = "STR",
                            Team_id = 5
                        },
                        new
                        {
                            Id = 11,
                            FastestLapList = "[0]",
                            FinishingPositions = "[10]",
                            Name = "Hulkenberg",
                            ShortName = "HUL",
                            Team_id = 8
                        },
                        new
                        {
                            Id = 15,
                            FastestLapList = "[0]",
                            FinishingPositions = "[11]",
                            Name = "Magnussen",
                            ShortName = "MAG",
                            Team_id = 8
                        },
                        new
                        {
                            Id = 12,
                            FastestLapList = "[0]",
                            FinishingPositions = "[12]",
                            Name = "Tsunoda",
                            ShortName = "TSU",
                            Team_id = 6
                        },
                        new
                        {
                            Id = 13,
                            FastestLapList = "[0]",
                            FinishingPositions = "[13]",
                            Name = "Ricciardo",
                            ShortName = "RIC",
                            Team_id = 6
                        },
                        new
                        {
                            Id = 14,
                            FastestLapList = "[0]",
                            FinishingPositions = "[14]",
                            Name = "Gasly",
                            ShortName = "GAS",
                            Team_id = 9
                        },
                        new
                        {
                            Id = 17,
                            FastestLapList = "[0]",
                            FinishingPositions = "[15]",
                            Name = "Ocon",
                            ShortName = "OCO",
                            Team_id = 9
                        },
                        new
                        {
                            Id = 16,
                            FastestLapList = "[0]",
                            FinishingPositions = "[16]",
                            Name = "Albon",
                            ShortName = "ALB",
                            Team_id = 7
                        },
                        new
                        {
                            Id = 19,
                            FastestLapList = "[0]",
                            FinishingPositions = "[17]",
                            Name = "Sargeant",
                            ShortName = "SAR",
                            Team_id = 7
                        },
                        new
                        {
                            Id = 18,
                            FastestLapList = "[0]",
                            FinishingPositions = "[19]",
                            Name = "Zhou",
                            ShortName = "ZHO",
                            Team_id = 4
                        },
                        new
                        {
                            Id = 20,
                            FastestLapList = "[0]",
                            FinishingPositions = "[20]",
                            Name = "Bottas",
                            ShortName = "BOT",
                            Team_id = 4
                        });
                });

            modelBuilder.Entity("F1Pontszamitos_S6.Shared.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RacesTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bahrain GP",
                            ShortName = "BHR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Las Vegas GP",
                            ShortName = "VEGAS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Miami GP",
                            ShortName = "MIAMI"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Brazilian GP",
                            ShortName = "BRAZ"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hungarian GP",
                            ShortName = "HUN"
                        });
                });

            modelBuilder.Entity("F1Pontszamitos_S6.Shared.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BgColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Driver_ids")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TeamsTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BgColor = "#021652",
                            Driver_ids = "[1,7]",
                            Name = "Red Bull"
                        },
                        new
                        {
                            Id = 2,
                            BgColor = "#fe0d0d",
                            Driver_ids = "[3,5]",
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = 3,
                            BgColor = "#ff6c0b",
                            Driver_ids = "[2,4]",
                            Name = "McLaren"
                        },
                        new
                        {
                            Id = 4,
                            BgColor = "#9f0d11",
                            Driver_ids = "[18,20]",
                            Name = "Alfa"
                        },
                        new
                        {
                            Id = 5,
                            BgColor = "#00533a",
                            Driver_ids = "[9,10]",
                            Name = "Aston"
                        },
                        new
                        {
                            Id = 6,
                            BgColor = "#0d3349",
                            Driver_ids = "[12,13]",
                            Name = "Tauri"
                        },
                        new
                        {
                            Id = 7,
                            BgColor = "#0b3b7a",
                            Driver_ids = "[16,19]",
                            Name = "Williams"
                        },
                        new
                        {
                            Id = 8,
                            BgColor = "#ffffff",
                            Driver_ids = "[11,15]",
                            Name = "Haas"
                        },
                        new
                        {
                            Id = 9,
                            BgColor = "#04111f",
                            Driver_ids = "[14,17]",
                            Name = "Alpine"
                        },
                        new
                        {
                            Id = 10,
                            BgColor = "#0da49f",
                            Driver_ids = "[6,8]",
                            Name = "Mercedes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
