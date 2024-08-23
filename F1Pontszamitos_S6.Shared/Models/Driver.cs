namespace F1Pontszamitos_S6.Shared.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }

        public int Point { get; set; }

        //Maybe a seperate Team class
        public string? Team { get; set; }

        public List<int>? FinishingPositions { get; set; }

        public int FastestLapCount { get; set; }


        public string getNamePNG()
        {
            return this.Name + ".png";
        }

        public string getTeamPNG()
        {
            return this.Team + ".png";
        }

        public string getTeamPNG2()
        {
            return this.Team + "2.png";
        }


    }
}
