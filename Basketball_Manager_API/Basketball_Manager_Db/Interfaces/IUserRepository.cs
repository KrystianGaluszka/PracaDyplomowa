using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<RankRequirementViewModel>> GetRankTable();
        Task<string> PostAccountCreate(RegisterPostModel registerPostModel);
        string GetJwt(LoginPostModel loginPostModel);
        UserViewModel GetUserById(string userId);
        Task<string> PutEditUser(UserPutModel userPutModel);
    }
}
