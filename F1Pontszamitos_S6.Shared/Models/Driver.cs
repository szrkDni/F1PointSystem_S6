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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? steamName {  get; set; }

        [Required]
        public string ShortName { get; set; }

        
        public int? Team_id { get; set; }

        public List<int>? FinishingPositions { get; set; }
        public List<int>? FastestLapList { get; set; }

        public List<List<UInt32>>? lapsByRaces = new();

        public bool isActive { get; set; }


        //without steam name, for AIs
        //in this case steam name is an empty list, not null
        public Driver(int id, string name, string shortName, int? team_id, bool isActive)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Team_id = team_id;
            this.isActive = isActive;
            steamName = "";

            FinishingPositions = new List<int>();
            FastestLapList = new List<int>();
        }

        //with steam name, for human players lol
        public Driver(int id, string name, string shortName, int? team_id, bool _isActive, string? _steamName)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Team_id = team_id;
            isActive = _isActive;
            steamName = _steamName;

            FinishingPositions = new List<int>();
            FastestLapList = new List<int>();
        }

        public Driver()
        {

        }

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
