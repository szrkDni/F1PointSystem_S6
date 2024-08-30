using F1Pontszamitos_S6.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> Driver_ids { get; set; }

        public string BgColor { get; set; }

        //Meg kell írni

        public int GetPoints(List<Driver> driversList)
        {
           var myDrivers = GetDrivers(driversList);
           return PointCounter.CountTeamPoint(myDrivers);
        }

        public List<Driver> GetDrivers(List<Driver> drivers)
        {
            return drivers.Where(x => x.Team_id == Id).ToList();
        }

        public int GetWinsCount(List<Driver> driversList)
        {
            var myDrivers = GetDrivers(driversList);

            var wins = 0;

            foreach (var driver in myDrivers)
            {
                wins += driver.FinishingPositions.Count(x => x == 1);
            }

            return wins;
        }

        public string getNamePNG()
        {
            return this.Name + ".png";
        }

    }
}
