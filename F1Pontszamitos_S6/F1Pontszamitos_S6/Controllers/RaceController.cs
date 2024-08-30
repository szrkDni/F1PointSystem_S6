using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/races")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly DriversDbContext _context;
        
        public RaceController(DriversDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Race>>> GetRaces()
        {
            return await _context.RacesTable.ToListAsync();
        }
    }
}
