using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IUsersMatchHistoryRepository
    {
        Task<IEnumerable<UsersMatchHistoryModel>> GetAllUsersMatchHistory();
        Task<UsersMatchHistoryModel> GetUsersMatchHistory(int id);
    }
}
