using CollectFourCore;
using CollectFourCore.Ratovanie;
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
    public class RateController : ControllerBase
    {
        private RateInterface rateService = new RatingTD();

        // GET: api/Rate
        [HttpGet]
        public IEnumerable<Rate> GetScores()
        {
            return rateService.GetRate();
        }

        // POST: api/Rate
        [HttpPost]
        public void Post([FromBody] Rate rate)
        {
            rateService.RattingAdd(rate);
        }
    }
}
