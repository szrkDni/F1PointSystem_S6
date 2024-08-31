using F1Pontszamitos_S6.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Interfaces
{
    public interface ITeam
    {
        public int GetPoints(List<Driver> driverList);
        public List<Driver> GetDrivers(List<Driver> driverList);
        public int GetWinsCount(List<Driver> driverList);
    }
}
