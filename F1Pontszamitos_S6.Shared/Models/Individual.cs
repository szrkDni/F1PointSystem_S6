using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Individual
    {
        public string Name { get;}

        public int FinishedPosition { get; }

        public Individual(string name, int finishedPosition)
        {
            Name = name;
            FinishedPosition = finishedPosition;
        }
    }
}
