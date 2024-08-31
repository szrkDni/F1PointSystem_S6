using F1Pontszamitos_S6.Shared.Models;

namespace F1Pontszamitos_S6.Test
{
    public class UnitTest1
    {
        protected List<Driver> driverListTest = new List<Driver>
            {  new Driver { Id = 1, Name = "Verstappen", ShortName = "VER", Team_id = 1, FinishingPositions = new List<int> { 3, 4, 1, 20 }, FastestLapList = new List<int> { 1, 0, 1, 0, 0 } },
                new Driver { Id = 7, Name = "Perez", ShortName = "PER", Team_id = 1, FinishingPositions = new List<int> { 6, 13, 20, 19 }, FastestLapList = new List<int> { 1, 0, 0, 1, 0 } },

                new Driver { Id = 2, Name = "Norris", ShortName = "NOR", Team_id = 3, FinishingPositions = new List<int> { 4, 2, 3, 4 }, FastestLapList = new List<int> { 1, 0, 0, 1, 0 } },
                new Driver { Id = 4, Name = "Piastri", ShortName = "PIA", Team_id = 3, FinishingPositions = new List<int> { 5, 7, 20, 3 }, FastestLapList = new List<int> { 1, 0, 0, 0, 1 } },

                new Driver { Id = 3, Name = "Leclerc", ShortName = "LEC", Team_id = 2, FinishingPositions = new List<int> { 1, 1, 1, 1 }, FastestLapList = new List<int> { 1, 0, 0, 0, 0 } },
                new Driver { Id = 5, Name = "Sainz", ShortName = "SAI", Team_id = 2, FinishingPositions = new List<int> { 2, 2, 2, 2 }, FastestLapList = new List<int> { 0, 1, 1, 1, 1 } }

        };

        protected List<Team> teamListTest = new List<Team>
            {
                new Team { Id = 1, Name = "Red Bull", BgColor = "#021652", Driver_ids = new List<int> { 1, 7 } },
                new Team { Id = 3, Name = "McLaren", BgColor = "#ff6c0b", Driver_ids = new List<int> { 2, 4 } },
                new Team { Id = 2, Name = "Ferrari", BgColor = "#fe0d0d", Driver_ids = new List<int> { 3, 5 } },

        };

        [Fact]
        public void TeamTest_GetWinsCount()
        {

            Assert.Equal(1, teamListTest[0].GetWinsCount(driverListTest));
            Assert.Equal(0, teamListTest[1].GetWinsCount(driverListTest));
            Assert.Equal(4, teamListTest[2].GetWinsCount(driverListTest));
            

        }

        [Fact]
        public void TeamTest_GetPoints()
        {
            Assert.Equal(63, teamListTest[0].GetPoints(driverListTest));
            Assert.Equal(91, teamListTest[1].GetPoints(driverListTest));
            Assert.Equal(176, teamListTest[2].GetPoints(driverListTest));
        }


        [Fact]
        public void DriverTest_GetPoints()
        {
            Assert.Equal(101, driverListTest[4].GetPoints());
            Assert.Equal(9, driverListTest[1].GetPoints());
        }
    }
}