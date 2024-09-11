using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Models;
using F1Pontszamitos_S6.Shared.QueryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly DriversDbContext _dbContext;

        public MainController(DriversDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<DriverTableModel>>> GetSomething()
        {


            var query = await _dbContext.DriversTable.Join(_dbContext.TeamsTable,
                driver => driver.Team_id,
                team => team.Id,
                (driver, team) =>
                     new DriverTableModel(driver.Name, team.Name, team.BgColor, driver.GetPoints()))
                .ToListAsync();

            var sortedQuery = query.OrderByDescending(x => x.Points).ToList();


            return query;
        }

        

        [HttpGet("nextRace")]
        public async Task<ActionResult<string>> GetNextRace()
        {
            var nextRaceId = _dbContext.DriversTable.First().FinishingPositions.Count + 1;
            var nextRace = await _dbContext.RacesTable.FindAsync(nextRaceId);

            if(nextRace is not null)
            {
                return nextRace.Name;
            }

            //If there isn't any more races left
            //Working on a different, better solution
            return NotFound("No more races left");
            
        }

        [HttpGet("currentRace")]
        public async Task<ActionResult<string>> GetCurrentRace()
        {
            var currentRaceId = _dbContext.DriversTable.First().FinishingPositions.Count;  
            var currentRace = await _dbContext.RacesTable.FindAsync(currentRaceId);

            if (currentRace is not null)
            {
                return currentRace.Name; 
                
            }

            //If somehow we managed to document another race after the last
            return Ok("How did we get here");

        }
    }
}
