using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IStadiumRepository
    {
        Task<IEnumerable<StadiumViewModel>> GetAllStadiums();
        Task<StadiumViewModel> GetStadium(int id);
        Task<string> UpgradeStadium(UpgradeStadiumPutModel upgradeStadiumPutModel);
        Task<string> ChangeStadiumName(StadiumPutModel stadiumPutModel);

    }
}
