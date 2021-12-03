using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUser(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> PostAccountCreate(RegisterPostModel registerPostModel)
        {
            var id = Guid.NewGuid().ToString();

            var item = _context.Items;
            var emptyItems = new List<UsersItemModel>();
            for (int i = 1; i <= item.Count(); i++)
            {
                emptyItems.Add(new UsersItemModel
                {
                    UserId = id,
                    Item = item.Where(x=>x.Id == i).FirstOrDefault(),
                    Count = 0
                });
            }

            var userDetails = new UsersMatchDetailsModel
            {
                UserId = id,
                MatchesDrawn = 0,
                MatchesLost = 0,
                MatchesPlayed = 0,
                MatchesWon = 0,
                RankPoints = 0
            };
            var userDetailsList = new List<UsersMatchDetailsModel> { userDetails };

            var userModel = new UserModel
            {
                Id = id,
                Name = registerPostModel.Name,
                Email = registerPostModel.Email,
                Password = registerPostModel.Password,
                BirthDate = registerPostModel.BirthDate.HasValue ? registerPostModel.BirthDate : null,
                Money = 25000,
                UsersItems = emptyItems,
                UserMatchesDetails = userDetailsList
            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return await _context.Users.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<UserModel> PostAccountLogin(LoginPostModel loginPostModel)
        {
            var users = _context.Users;

            var user = await users.Where(x => x.Email == loginPostModel.Email).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.Password == loginPostModel.Password)
                {
                    return user;
                }
                else
                {
                    return new UserModel { };
                }
            }



            return  new UserModel { };
        }
    }
}
