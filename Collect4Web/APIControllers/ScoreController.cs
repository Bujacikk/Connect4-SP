using CollectFour;
using CollectFourCore.Score;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collect4Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private ScoreInterface scoreService = new ScoreboardTD();
        

        // GET: api/Score
        [HttpGet]
        public IEnumerable<Player> GetScores()
        {
            return scoreService.GetTopScores();
        }

        // POST: api/Score
        [HttpPost]
        public void Post([FromBody] Player player)
        {
            scoreService.PlayerAdd(player);
        }
    }
}
  