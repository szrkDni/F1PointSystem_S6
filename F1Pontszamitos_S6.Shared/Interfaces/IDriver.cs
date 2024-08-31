using F1Pontszamitos_S6.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Interfaces
{
    public interface IDriver
    {
        public int GetPoints();
        public string GetBgColor(List<Team> teamList);
        public string GetTeamName(List<Team> teamList);
    }
}
