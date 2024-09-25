using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Utils
{
    public class ConsoleWriter
    {
        public static void WriteAllToConsole(FinalClassificationData data)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Finishing Position: {data.m_position}");
            Console.WriteLine($"Number of Laps Completed: {data.m_numLaps}");
            Console.WriteLine($"Grid Position: {data.m_gridPosition}");
            Console.WriteLine($"Points Scored: {data.m_points}");
            Console.WriteLine($"Number of Pit Stops Made: {data.m_numPitStops}");
            Console.WriteLine($"Result Status: {data.m_resultStatus}");
            Console.WriteLine($"Best Lap Time (in MS): {data.m_bestLapTimeInMS}");
            Console.WriteLine($"Total Race Time (in Seconds): {data.m_totalRaceTime}");
            Console.WriteLine($"Total Penalties Time (in Seconds): {data.m_penaltiesTime}");
            Console.WriteLine($"Number of Penalties: {data.m_numPenalties}");
            Console.WriteLine($"Number of Tyre Stints: {data.m_numTyreStints}");

            for (int i = 0; i < data.m_tyreStintsActual.Length; i++)
            {
                Console.WriteLine($"Tyre Stint Actual {i + 1}: {data.m_tyreStintsActual[i]}");
            }

            for (int i = 0; i < data.m_tyreStintsVisual.Length; i++)
            {
                Console.WriteLine($"Tyre Stint Visual {i + 1}: {data.m_tyreStintsVisual[i]}");
            }

            for (int i = 0; i < data.m_tyreStintsEndLaps.Length; i++)
            {
                Console.WriteLine($"Tyre Stint End Lap {i + 1}: {data.m_tyreStintsEndLaps[i]}");
            }
        }

        public static void WriteFinishPos(FinalClassificationData data)
        {
            Console.WriteLine(data.m_position.ToString());
        }
    }
}
