using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface ISponsorRepository
    {
        Task<IEnumerable<UsersSponsorViewModel>> GetAllUserSponsors();
        Task<UsersSponsorViewModel> GetUserSponsor(int id);
        Task<IEnumerable<SponsorsViewModel>> GetAllSponsors();
        Task<SponsorsViewModel> GetSponsor(int id);

        Task<string> ChangeSponsor(ChangeSponsorPutModel changeSponsorPutModel);
    }
}
