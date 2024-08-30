using F1Pontszamitos_S6.Shared.Utils;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Driver
    {

        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? ShortName { get; set; }

        public int? Team_id { get; set; }

        public List<int>? FinishingPositions { get; set; }

        public List<int> FastestLapList { get; set; }



        //public string getNamePNG()
        //{
        //    return this.Name + ".png";
        //}

        //public string getTeamPNG()
        //{
        //    return this.Team + ".png";
        //}

        //public string getTeamPNG2()
        //{
        //    return this.Team + "2.png";
        //}


        //Meg kell írni
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
