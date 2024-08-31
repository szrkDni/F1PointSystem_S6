using F1Pontszamitos_S6.DataB;
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

            
            return unsorted.OrderByDescending(x => x.GetPoints()).ToList();
        }

        [HttpPut("{driverName}/{position}/{fastestMan}")]
        public async Task<ActionResult<Driver>> UpdateDriverAsync(string driverName, int position, string fastestMan)
        {
            var driver = await _dbContext.DriversTable.Where(x => x.Name.Equals(driverName)).FirstOrDefaultAsync();

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

                return Ok(driver);
            }
        }

    }
}
