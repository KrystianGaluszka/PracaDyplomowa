using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.GetModel;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsersMatchHistoryViewModel> GetActualMatch(string userId)
        {
            var match = _context.UsersMatchesHistory.Where(x => x.UserId == userId || x.User2Id == userId).OrderBy(x => x.Id).LastOrDefault();

            var config = MapperConfig();
            var mapper = new Mapper(config);

            var matchModel = mapper.Map<UsersMatchHistoryModel, UsersMatchHistoryViewModel>(match);

            return matchModel;
        }

        public async Task<BackgroundTaskViewModel> GetTask(string userId)
        {
            var task = _context.BackgroundTasks.Where(x => x.TaskName == "match").OrderBy(x => x.Id).LastOrDefault(x => x.UserId == userId || x.User2Id == userId);

            if (task != null)
            {
                var config = MapperConfig();
                var mapper = new Mapper(config);

                var taskModel = mapper.Map<BackgroundTaskModel, BackgroundTaskViewModel>(task);

                return taskModel;
            }
            else return null;
            
        }

        public async Task<GetTimeModel> GetTime(string userId)
        {
            var match = _context.UsersMatchesHistory.Where(x => x.UserId == userId || x.User2Id == userId).OrderBy(x => x.Id).LastOrDefault();

            return new GetTimeModel
            {
                Minutes = match.MinutesLeft,
                Seconds = match.SecondsLeft
            };
        }
    }
}
