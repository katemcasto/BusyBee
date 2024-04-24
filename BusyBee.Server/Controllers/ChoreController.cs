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
            ChoreDataService dataService = new ChoreDataService();
            List<Chore> choreList = dataService.GetChores();
            return choreList;
        }
    }
}
