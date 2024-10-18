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
        public bool running = false;

        private readonly DriversDbContext _dbContext;

        public UdpControlller(DriversDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("start")]
        public async Task<ActionResult<List<Individual>>> StartUdpListener()
        {
            if (running) return Ok("Already Running");

            running = true;
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

                    if (driver is not null)
                    {
                        driver.FinishingPositions.Add(item.FinishedPosition);
                        driver.lapsByRaces.Add(item.listOfLaps);
                        
                        ManageFastestLap(item, driver);
                    }
                    else if (item.Id == 0) //Sainz
                    {
                        driver = _dbContext.DriversTable.Find(1);

                        driver.FinishingPositions.Add(item.FinishedPosition);
                        driver.lapsByRaces.Add(item.listOfLaps);
                        ManageFastestLap(item, driver);
                    }
                    else if(item.Id == 255)
                    {
                        string name = item.Name.Replace("\0", "");
                        var player = _dbContext.DriversTable.FirstOrDefault(x => x.steamName == name);

                        AddToDatabase(item, player.steamName);
                        

                        //switch (name)
                        //{
                        //    case "D":
                        //        AddToDatabase(item, "Dani");
                        //        break;
                        //    case "BMark2002":
                        //        AddToDatabase(item, "Bagossy");
                        //        break;
                        //    case "BernerCs":
                        //        AddToDatabase(item, "Berner");
                        //        break;
                        //    default:
                        //        Console.Error.WriteLine("Player not found in database!");
                        //        break;
                        //}
                    }
                }
            }


            //Azoknak is ad pontot akik inactivak ha a player helyett mennek
            //Itt csak azoknak ir 21. rajthelyett akik fent nem kaptak versenyeredmenyt (tehat nem vettek reszt a futamon)


            var database = _dbContext.DriversTable.ToList();
            var maxRange = database.Max(x => x.FinishingPositions.Count);

            foreach (var item in database)
            {
                if (item.FinishingPositions.Count < maxRange)
                {
                    item.FinishingPositions.Add(21);
                    item.FastestLapList.Add(0);
                    item.lapsByRaces.Add(new List<UInt32> { 0 });
                }
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
            Console.Clear();

            if(running)
            {
                _udpListener.StopListening();
                _cancellationTokenSource.Cancel();
                _udpListener = null;
                _cancellationTokenSource = null;
                Console.WriteLine("UDP listener stopped.");
            }
            
            return Ok("UDP listener stopped.");
        }

        [HttpGet("dispose")]
        public void StopByDispose()
        {
            _ = StopUdpListener();

            //return Ok("UDP listener stopped.");
        }

        private void AddToDatabase(Individual item, string tableName)
        {
            var driver = _dbContext.DriversTable.FirstOrDefault(x => string.Equals(x.steamName, tableName));

            if (driver.isActive)
            {
                driver.FinishingPositions.Add(item.FinishedPosition);
                driver.lapsByRaces.Add(item.listOfLaps);
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

