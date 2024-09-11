using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.QueryModels
{
    public class DriverTableModel
    {
        public int DriverId { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
        public string Team_name { get; set; }

        public DriverTableModel(int driverId, string name, int teamId, string team_name)
        {
            DriverId = driverId;
            Name = name;
            TeamId = teamId;
            Team_name = team_name;
        }
    }
}
