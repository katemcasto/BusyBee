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
            return _choresRepo.GetChores();
        }

        [HttpPost(Name = "AddChore")]
        public int Add(Chore chore)
        {
            return _choresRepo.AddChore(chore);
        }

        [HttpPatch(Name = "UpdateChore")]
        public int Update(Chore chore)
        {
            return _choresRepo.UpdateChore(chore);
        }

        [HttpDelete(Name = "DeleteChore")]
        public int Delete(Chore chore) 
        {
            return _choresRepo.DeleteChore(chore);
        }
    }
}