using Basketball_Manager_Db.Models;
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
        Task<PlayerViewModel> GetPlayer(int id);
        Task<UsersPlayerModel> PostAddPlayer(int id, string userId);
    }
}
