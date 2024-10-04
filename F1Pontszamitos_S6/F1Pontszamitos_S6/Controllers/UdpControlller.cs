using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1Pontszamitos_S6.Shared.Utils;
using F1Pontszamitos_S6.Shared.Models;
using F1Pontszamitos_S6.DataB;
using F1Pontszamitos_S6.Shared.Interfaces;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/udp")]
    [ApiController]
    public class UdpControlller : ControllerBase
    {
        private static UdpListener _udpListener;
        private static CancellationTokenSource _cancellationTokenSource;
        public uint fastest;

        private readonly DriversDbContext _dbContext;

        public UdpControlller(DriversDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("start")]
        public async Task<ActionResult<List<Individual>>> StartUdpListener()
        {

            _cancellationTokenSource = new CancellationTokenSource();
            _udpListener = new UdpListener(20777); // UDP port

            //Await function lett a StartListening function a threadsek miatt
            List<Individual> individuals = await _udpListener.StartListeningAsync(_cancellationTokenSource.Token);

            //Minimum time
            fastest = individuals.Where(x => x.bestLaptime != 0).Min(i => i.bestLaptime);

            foreach (var item in individuals)
            {
                if (item.FinishedPosition != 0)
                {
                    //if id is 0 or 255 -> driver is null else not null
                    var driver = _dbContext.DriversTable.Find(item.Id);

                    if (driver is not null && driver.isActive)
                    {
                        driver.FinishingPositions.Add(item.FinishedPosition);
                        ManageFastestLap(item, driver);
                    }
                    else if (item.Id == 0) //Sainz
                    {
                        driver = _dbContext.DriversTable.Find(1);

                        if (driver.isActive)
                        {
                            driver.FinishingPositions.Add(item.FinishedPosition);
                            //driver.FastestLapList.Add(0);
                            ManageFastestLap(item, driver);
                        }
                    }
                    else if(item.Id == 255)
                    {
                        string name = item.Name.Replace("\0", "");

                        switch (name)
                        {
                            case "D":
                                AddToDatabase(item, "Szarka");
                                break;
                            case "BMark2002":
                                AddToDatabase(item, "Bagosi");
                                break;
                            case "BernerCs":
                                AddToDatabase(item, "Berner");
                                break;
                            default:
                                Console.Error.WriteLine("Player not found in database!");
                                break;
                        }
                    }
                }
            }

            var inactive = _dbContext.DriversTable.Where(x => !x.isActive);
            foreach (var item in inactive) 
            {
                item.FinishingPositions.Add(21);
                item.FastestLapList.Add(0);
            }

            

            //Individual with the minimum time
            //Individual individualWithLowestTime = individuals.FirstOrDefault(i => i.bestLaptime == minTime);

            _dbContext.SaveChangesAsync();

            _ = StopUdpListener();
            return Ok(individuals);
        }

        [HttpGet("stop")]
        public IActionResult StopUdpListener()
        {
            // Leállítjuk az UDP szervert
            _udpListener.StopListening();
            _cancellationTokenSource.Cancel();
            _udpListener = null;
            _cancellationTokenSource = null;

            return Ok("UDP listener stopped.");
        }

        private void AddToDatabase(Individual item, string tableName)
        {
            var driver = _dbContext.DriversTable.FirstOrDefault(x => string.Equals(x.Name, tableName));

            if (driver.isActive)
            {
                driver.FinishingPositions.Add(item.FinishedPosition);
                ManageFastestLap(item, driver); ;
            }
        }

        private void ManageFastestLap(Individual individual, Driver driver)
        {
            bool taken = false;
            if(fastest == individual.bestLaptime && !taken)
            {
                driver.FastestLapList.Add(1);
                taken = true;
            }else{
                driver.FastestLapList.Add(0);
            }
        }

    }
}

