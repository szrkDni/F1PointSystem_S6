using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Interfaces;
using F1Pontszamitos_S6.Shared.Models;
using F1Pontszamitos_S6.Shared.QueryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<ActionResult<List<Driver>>> GetAllActiveDriversAsync()
        {
            var alldrivers = _dbContext.DriversTable;
            //var unsorted = await alldrivers.Where(x => x.isActive || (!x.isActive && x.FinishingPositions.Min(y => y <= 10))).ToListAsync();
            var unsorted = await alldrivers.Where(x => x.isActive).ToListAsync();

            if (unsorted is null)
            {
                return Ok(new List<Driver>());
            }

            if (!unsorted[0].FinishingPositions.Any())
            {
                return unsorted.ToList();
            }


            return DriverSort(unsorted);
        }

        [HttpGet("includeInactive")] //MINDET VISSZAADJA MEG AZ INACTIVAKAT IS
        public async Task<ActionResult<List<Driver>>> GetAllDriversInactiveAsync()
        {
            var alldrivers = _dbContext.DriversTable;
            var unsorted = await alldrivers.ToListAsync();

            if (unsorted is null)
            {
                return Ok(new List<Driver>());
            }

            if (!unsorted[0].FinishingPositions.Any())
            {
                return unsorted.ToList();
            }

            return DriverSort(unsorted);
        }

        [HttpGet("previous")]
        public async Task<ActionResult<List<Driver>>> GetPreviousOrder()
        {
            var alldrivers = _dbContext.DriversTable;
            var previous = await alldrivers.Where(x => x.isActive).ToListAsync();
            //var previous = await alldrivers.ToListAsync();

            if (previous is null) return Ok(new List<Driver>());

            if (previous[0].FinishingPositions.Any())
            {
                for (int i = 0; i < previous.Count; i++)
                {
                    previous[i].FinishingPositions.RemoveAt(previous[i].FinishingPositions.Count - 1);
                }
            }

            return DriverSort(previous);
        }


        [HttpGet("names")]
        public async Task<ActionResult<List<string>>> GetAllDriversNames()
        {
            var driverNames = await _dbContext.DriversTable.Where(x => x.isActive).Select(x => x.Name).ToListAsync();

            return driverNames;
        }

        [HttpGet("leader")]
        public async Task<ActionResult<Driver>> GetLeader()
        {
            return await _dbContext.DriversTable.FirstAsync();
        }

        [HttpGet("namesnids")] //NewResultban mostmár tudunk inaktív versenyzőket regisztrálni
        public async Task<ActionResult<Dictionary<int, string>>> GetNamesAndIds()
        {
            var query = await _dbContext.DriversTable
                .OrderBy(x => x.isActive? 0 : 1)
                .ThenBy(x => x.Team_id)
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            return Ok(query);
        }


        [HttpPut("namesnids/inactive/")]
        public IActionResult PutNamesAndIdsInactive([FromBody] int[] idList)
        {

            var query = _dbContext.DriversTable.Where(x => !idList.Contains(x.Id)).ToList();

            foreach (var item in query)
            {
                item.FinishingPositions.Add(21);
                item.FastestLapList.Add(0);
            }

            _dbContext.SaveChanges();

            return Ok();
        }

        //Add new race result
        //The input parameters are based of the options of a dropdown list

        [HttpPut("{driverId:int}/{position:int}/{fastestManId:int}")]
        public async Task<ActionResult<Driver>> UpdateDriverAsync(int driverId, int position, int fastestManId)
        {
            //Shouldn't check if driver is active or not, because from the dropdown list, you only can select the active drivers
            var driver = await _dbContext.DriversTable.FindAsync(driverId);

            //Not really possible because we select this driver from a dropdown list
            if (driver is null)
            {
                return NotFound("No driver with this name in the database");
            }
            else
            {
                var newFinishingPosions = driver.FinishingPositions;
                newFinishingPosions.Add(position);


                driver.FinishingPositions = newFinishingPosions;



                var newFastestLapList = driver.FastestLapList;

                if (driver.Id == fastestManId)
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


        /*Még tesztelni mindenképp*/
        [HttpPut("addCustom/{d_name}/{d_shortname}/{d_steamName}/{d_teamId:int}")]
        public async Task<ActionResult<Driver>> AddNewCustomDriver(string d_name, string d_shortname, string d_steamName, int d_teamId)
        {
            var maxId = _dbContext.DriversTable.Max(x => x.Id);
            maxId = maxId < 170 ? maxId = 170 : maxId;


            Driver driver = new Driver { Name = d_name, Id =  ++maxId, ShortName = d_shortname, FastestLapList = new(), FinishingPositions = new(), isActive = true, Team_id = d_teamId, steamName = d_steamName};

            var itsTeam = _dbContext.TeamsTable.Find(driver.Team_id);
            itsTeam.Driver_ids.Add(driver.Id);
            

            _dbContext.DriversTable.Add(driver);
            await _dbContext.SaveChangesAsync();

            return Ok("Custom driver added successfully");
        }

        [HttpPut("modifyIsActive/{id:int}")]
        public async Task<ActionResult<Driver>> ModifyIsActiveAttibute(int id)
        {
            var driver = _dbContext.DriversTable.Find(id);

            driver.isActive = false;

            await _dbContext.SaveChangesAsync();

            return Ok("Driver inactivated successfully");
        }
        
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            var driver = await _dbContext.DriversTable.FindAsync(id);

            var whorepleace = await _dbContext.DriversTable.Where(x => x.Team_id == driver.Team_id && !x.isActive).FirstAsync();

            whorepleace.isActive = true;

            _dbContext.DriversTable.Remove(driver);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("modifyRaceResult/{index:int}/{id:int}/{newResult:int}")]
        public async Task<ActionResult<Driver>> ModifyRaceResultAsync(int index ,int id, int newResult)
        {
            var driver = _dbContext.DriversTable.Find(id);
            driver.FinishingPositions[index] = newResult;

            await _dbContext.SaveChangesAsync();
            return Ok("Race results updated");
        }

        /***************************************************************************/
        private List<Driver> DriverSort(List<Driver> driver)
        {
            return driver.OrderByDescending(d => d.GetPoints())
                        //For wont work :)))
                        .ThenBy(d => d.FinishingPositions.Any() ? d.FinishingPositions.Min() : int.MaxValue)
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