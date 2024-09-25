using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F1Pontszamitos_S6.Shared.Utils;
using F1Pontszamitos_S6.Shared.Models;

namespace F1Pontszamitos_S6.Controllers
{
    [Route("api/udp")]
    [ApiController]
    public class UdpControlller : ControllerBase
    {
        private static UdpListener _udpListener;
        private static CancellationTokenSource _cancellationTokenSource;

        [HttpGet("start")]
        public async Task<ActionResult<List<Individual>>> StartUdpListener()
        {
            List<Individual> individuals = new List<Individual>();

          

            _cancellationTokenSource = new CancellationTokenSource();
            _udpListener = new UdpListener(20777); // UDP port



            individuals = _udpListener.StartListening(_cancellationTokenSource.Token);

            _ = StopUdpListener();

            return individuals;
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
    }
}

