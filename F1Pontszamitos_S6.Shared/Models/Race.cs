using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Race
    {
        private static int ID = 0;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public Race(string name, string shortName)
        {
            ID++;
            Id = ID;
            Name = name;
            ShortName = shortName;
        }
    }
}
