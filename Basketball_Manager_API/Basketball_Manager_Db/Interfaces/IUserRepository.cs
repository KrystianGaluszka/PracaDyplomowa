using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUser(string id);
        Task<UserModel> PostAccountCreate(RegisterPostModel registerPostModel);

        Task<UserModel> PostAccountLogin(LoginPostModel loginPostModel);
    }
}
