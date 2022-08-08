using Microsoft.AspNetCore.Mvc;
using SportingGroupAPI.Models;
using SportingGroupAPI.Services;

namespace SportingGroupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IFixtureService _service;

        public FixtureController(IFixtureService service)
        {
            _service = service;
        }

        // GET: api/<FixtureController>
        [HttpGet]
        public async Task<IEnumerable<ApiGetFixture>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<FixtureController>/5
        [HttpGet("{id}")]
        public async Task<ApiGetFixture> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        // POST api/<FixtureController>
        [HttpPost]
        public async Task PostAsync([FromBody] ApiPostFixture request)
        {
            await _service.PostAsync(request);
        }
    }
}
