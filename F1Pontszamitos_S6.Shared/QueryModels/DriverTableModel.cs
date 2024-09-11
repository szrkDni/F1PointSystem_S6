using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.QueryModels
{
    public class DriverTableModel
    {
        public string Name { get; set; }

        public string Team_name { get; set; }

        public string BgColor { get; set; }

        public int Points { get; set; }

        public DriverTableModel(string name, string team_name, string bgColor, int points)
        {
            Name = name;
            Team_name = team_name;
            BgColor = bgColor;
            Points = points;
        }
    }
}
