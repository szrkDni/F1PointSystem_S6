using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DriversDbContext _dbContext;

        public TeamController(DriversDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {

            return await _dbContext.TeamsTable.ToListAsync();
        }

        
    
    }
}
