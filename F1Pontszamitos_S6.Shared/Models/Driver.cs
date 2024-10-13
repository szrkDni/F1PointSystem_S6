using F1Pontszamitos_S6.Shared.Interfaces;
using F1Pontszamitos_S6.Shared.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Driver : IDriver
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        
        public int? Team_id { get; set; }

        public List<int>? FinishingPositions { get; set; }

        public List<int>? FastestLapList { get; set; }

        public List<List<UInt32>>? lapsByRaces = new ();

        public bool isActive { get; set; }

        public int GetPoints()
        {
            return PointCounter.CountDriverPoint(this);
        }

        public string GetBgColor(List<Team> teamList)
        {
            return teamList.Where(x => x.Id == this.Team_id).FirstOrDefault().BgColor;
        }

        public string GetTeamName(List<Team> teamList) 
        {
            return teamList.Where(x => x.Id == this.Team_id).FirstOrDefault().Name;
        }
    }
}
