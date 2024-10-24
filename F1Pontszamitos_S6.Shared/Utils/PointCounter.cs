﻿using F1Pontszamitos_S6.Shared.Models;

namespace F1Pontszamitos_S6.Shared.Utils
{
    public class PointCounter
    {
        private static readonly Dictionary<int, int> _pointSystemDict = new Dictionary<int, int>
        {
            {1, 25},
            {2, 18},
            {3, 15},
            {4, 12},
            {5, 10},
            {6, 8},
            {7, 6},
            {8, 4},
            {9, 2},
            {10, 1}
        };


        public static int CountDriverPoint(Driver driver)
        {
            var points = 0;

            var finisingPositions = driver.FinishingPositions;

            var fastestLaps = driver.FastestLapList;





            for (int i = 0; i < finisingPositions.Count; i++)
            {
                if (_pointSystemDict.ContainsKey(finisingPositions[i]))
                {
                    points += _pointSystemDict[finisingPositions[i]] + fastestLaps[i];
                }
            }

            return points;
        }

        public static int CountTeamPoint(List<Driver> team_drivers)
        {
            var points = 0;

            foreach (var drivers in team_drivers)
            {
                points += drivers.GetPoints();
            }

            return points;
        }
    }
}