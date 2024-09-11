using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Interfaces;
using F1Pontszamitos_S6.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriversDbContext _dbContext;

        public DriversController(DriversDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetAllDriversAsync()
        {
            var unsorted = await _dbContext.DriversTable.ToListAsync();


            if (!unsorted[0].FinishingPositions.Any()) {
                return unsorted.ToList();
            }


            return DriverSort(unsorted);
        }


        [HttpGet("previous")]
        public async Task<ActionResult<List<Driver>>> GetPreviousOrder()
        {
            var previous = await _dbContext.DriversTable.ToListAsync();

            for (int i = 0; i < previous.Count; i++)
            {
                previous[i].FinishingPositions.RemoveAt(previous[i].FinishingPositions.Count - 1);
            }

            return DriverSort(previous);
        }


        [HttpGet("names")]
        public async Task<ActionResult<List<string>>> GetAllDriversNames()
        {
            var driverNames = _dbContext.DriversTable.Select(x => x.Name).ToList();

            return driverNames;
        }


        //Add new race result

        [HttpPut("{driverName}/{position}/{fastestMan}")]
        public async Task<ActionResult<Driver>> UpdateDriverAsync(string driverName, int position, string fastestMan)
        {
            var driver = await _dbContext.DriversTable.Where(x => x.Name.Equals(driverName)).FirstOrDefaultAsync();

            //Not really possible since we got a list of them
            if (driver == null)
            {
                return NotFound();
            }
            else
            {
                var newFinishingPosions = driver.FinishingPositions;
                newFinishingPosions.Add(position);


                driver.FinishingPositions = newFinishingPosions;



                var newFastestLapList = driver.FastestLapList;

                if (driver.Name.Equals(fastestMan))
                {
                    newFastestLapList.Add(1);
                }
                else
                {
                    newFastestLapList.Add(0);
                }

                driver.FastestLapList = newFastestLapList;


                await _dbContext.SaveChangesAsync();

                return Ok();
            }
        }

        private List<Driver> DriverSort(List<Driver> driver)
        {
            return driver.OrderByDescending(d => d.GetPoints())
                        //For wont work :)))
                        .ThenBy(d => d.FinishingPositions.Min())
                        .ThenBy(d => d.FinishingPositions.Count > 1 ? d.FinishingPositions.OrderBy(p => p).ElementAt(1) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 2 ? d.FinishingPositions.OrderBy(p => p).ElementAt(2) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 3 ? d.FinishingPositions.OrderBy(p => p).ElementAt(3) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 4 ? d.FinishingPositions.OrderBy(p => p).ElementAt(4) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 5 ? d.FinishingPositions.OrderBy(p => p).ElementAt(5) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 6 ? d.FinishingPositions.OrderBy(p => p).ElementAt(6) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 7 ? d.FinishingPositions.OrderBy(p => p).ElementAt(7) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 8 ? d.FinishingPositions.OrderBy(p => p).ElementAt(8) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 9 ? d.FinishingPositions.OrderBy(p => p).ElementAt(9) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 10 ? d.FinishingPositions.OrderBy(p => p).ElementAt(10) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 11 ? d.FinishingPositions.OrderBy(p => p).ElementAt(11) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 12 ? d.FinishingPositions.OrderBy(p => p).ElementAt(12) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 13 ? d.FinishingPositions.OrderBy(p => p).ElementAt(13) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 14 ? d.FinishingPositions.OrderBy(p => p).ElementAt(14) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 15 ? d.FinishingPositions.OrderBy(p => p).ElementAt(15) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 16 ? d.FinishingPositions.OrderBy(p => p).ElementAt(16) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 17 ? d.FinishingPositions.OrderBy(p => p).ElementAt(17) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 18 ? d.FinishingPositions.OrderBy(p => p).ElementAt(18) : int.MaxValue)
                        .ThenBy(d => d.FinishingPositions.Count > 19 ? d.FinishingPositions.OrderBy(p => p).ElementAt(19) : int.MaxValue)
                        .ToList();
        }

    }

    
}