using BusyBee.DAL;

namespace BusyBee.BLL
{
    public class ChoresRepo
    {
        private ChoresService _choresService;

        public ChoresRepo(ChoresService choresService) 
        {
            _choresService = choresService;
        }

        public int AddChore(Chore chore)
        {
            return _choresService.AddChore(chore);
        }
    }
}