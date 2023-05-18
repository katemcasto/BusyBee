using BusyBee.BLL;
using BusyBee.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoresController : ControllerBase
    {
        private readonly ILogger<ChoresController> _logger;
        private ChoresRepo _choresRepo;

        public ChoresController(ILogger<ChoresController> logger, ChoresRepo choresRepo)
        {
            _logger = logger;
            _choresRepo = choresRepo; 
        }

        [HttpGet(Name = "GetChores")]
        public IEnumerable<Chore> Get()
        {
            List<Chore> chores = new List<Chore>();

            return chores;
        }

        [HttpPost(Name = "AddChore")]
        public void Add(Chore chore)
        {
            _choresRepo.AddChore(chore);
        }
    }
}