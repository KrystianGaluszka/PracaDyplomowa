using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<PlayerViewModel>> GetAllPlayers();
        Task<IEnumerable<UsersPlayerViewModel>> GetAllUsersPlayers();
        Task<PlayerViewModel> GetPlayer(int id);
        Task<string> EditTeam(EditTeamPutModel editTeamPutModel);
        Task<string> UpdateTraining(UpdateTrainingPutModel updateTraining);
    }
}
