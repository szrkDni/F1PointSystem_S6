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
        public async Task<ActionResult<List<Driver>>> GetAllDrivers()
        {
            return await _dbContext.DriversTable.ToListAsync();
        }

    }
}
