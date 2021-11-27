using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IUsersPlayerRepository
    {
        Task<IEnumerable<UsersPlayerModel>> GetAllUsersPlayers();
        Task<UsersPlayerModel> GetUsersPlayer(int id);
    }
}
