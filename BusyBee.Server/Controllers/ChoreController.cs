using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoreController : ControllerBase
    {
        private readonly ILogger<ChoreController> _logger;

        public ChoreController(ILogger<ChoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetChores")]
        public IEnumerable<Chore> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Chore
            {
                Name = "Test",
                CreatedBy = "Test"
            })
            .ToArray();
        }
    }
}
