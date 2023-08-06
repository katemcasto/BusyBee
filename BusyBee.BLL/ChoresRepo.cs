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

        public List<Chore> GetChores()
        {
            List<Chore> chores = _choresService.GetChores();

            return chores;
        }

        public int UpdateChore(Chore chore)
        {
            return _choresService.UpdateChore(chore);
        }
    }
}