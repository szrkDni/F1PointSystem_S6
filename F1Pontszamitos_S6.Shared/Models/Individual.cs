using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class Individual
    {

        public int Id { get; }
        public string Name { get;}

        public int FinishedPosition { get; }

        public Individual(int id, string name, int finishedPosition)
        {
            Id = id;
            Name = name;
            FinishedPosition = finishedPosition;
        }
    }
}
