using Microsoft.AspNetCore.Mvc;
using SportingGroupAPI.Models;
using SportingGroupAPI.Services;

namespace SportingGroupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettingController : ControllerBase
    {
        private readonly IBettingService _service;

        public BettingController(IBettingService service)
        {
            _service = service;
        }

        // GET api/<BettingController>/5
        [HttpGet("{id}")]
        public async Task<ApiGetBet> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        // POST api/<BettingController>
        [HttpPost]
        public async Task Post([FromBody] IEnumerable<ApiPostBetFixture> request)
        {
            await _service.PostAsync(request);
        }
    }
}
