using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IPlayerInfoRepository
    {
        Task<IEnumerable<PlayerInfoModel>> GetAllPlayersInfo();
        Task<PlayerInfoModel> GetPlayerInfo(int id);
    }
}
