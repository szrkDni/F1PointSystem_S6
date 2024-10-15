using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Models
{
    public class ModifiedDriver
    {
        public Driver driver;
        public int newResult;

        public ModifiedDriver(Driver _driver, int index)
        {
            driver = _driver;
            newResult = _driver.FinishingPositions[index];
        }
    }
}
