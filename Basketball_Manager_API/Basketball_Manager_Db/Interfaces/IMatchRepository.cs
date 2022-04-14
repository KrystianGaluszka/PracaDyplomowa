using Basketball_Manager_Db.GetModel;
using Basketball_Manager_Db.ViewModel;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IMatchRepository
    {
        public Task<UsersMatchHistoryViewModel> GetActualMatch(string userId);

        public Task<BackgroundTaskViewModel> GetTask(string userId);

        public Task<GetTimeModel> GetTime(string userId);
    }
}
