using AutoMapper;
using Basketball_Manager_Db.Helpers;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService_Db _jwtService;

        public UserRepository(JwtService_Db jwtService, ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync(); 
            
            var config = MapperConfig();
            var mapper = new Mapper(config);

            var usersModel = mapper.Map<List<UserModel>, List<UserViewModel>>(users);

            return usersModel;
        }

        public async Task<UserViewModel> GetUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            var config = MapperConfig();
            var mapper = new Mapper(config);

            var userModel = mapper.Map<UserModel, UserViewModel>(user);

            return userModel;
        }

        public async Task<string> PostAccountCreate(RegisterPostModel registerPostModel)
        {
            var emails = _context.Users.Select(x => x.Email);
            if (emails.Contains(registerPostModel.Email))
            {
                return null;
            }
            var id = Guid.NewGuid().ToString();
            var config = MapperConfig();
            var mapper = new Mapper(config);

            var userModel = mapper.Map<RegisterPostModel, UserModel>(registerPostModel);
            userModel.Id = id;
            userModel.Money = 25000;
            userModel.UsersItems = EmptyItems(id);
            userModel.UserDetail = EmptyDetails(id);
            
            var result = _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return "account_registered_successfully";
        }

        public  string GetJwt(LoginPostModel loginPostModel)
        {
            var users = _context.Users;
            var isExisting = users.Where(x => x.Email == loginPostModel.Email).Any();

            if (isExisting)
            {
                var user = users.Where(x => x.Email == loginPostModel.Email).FirstOrDefault();

                if (user.Password == loginPostModel.Password)
                {
                    var jwt = _jwtService.generate(user.Id);

                    return jwt;
                }
                else
                {
                    return "failed";
                }
            }
            return "failed";
        }

        public UserViewModel GetUserById(string userId)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.Id == userId);
            var config = MapperConfig();
            var mapper = new Mapper(config);
            var user = mapper.Map<UserModel, UserViewModel>(userModel);
            return user;
        }

        public async Task<string> PutEditUser(UserPutModel userPutModel)
        {
            var user = _context.Users.Find(userPutModel.Id);

            if (user != null)
            {
                user.ClubName = userPutModel.ClubName != "" ? userPutModel.ClubName : user.ClubName;
                user.Country = userPutModel.Country != "" ? userPutModel.Country : user.Country;
                user.Password = userPutModel.Password != "" ? userPutModel.Password : user.Password;
                user.ProfilePicturePath = userPutModel.ProfilePicturePath != "" ? userPutModel.ProfilePicturePath: user.ProfilePicturePath;
                await _context.SaveChangesAsync();
                return "ok";
            }
            else return "not_ok";
        }

        public IEnumerable<UsersItemModel> EmptyItems(string userId)
        {
            var emptyItems = new List<UsersItemModel>();
            var items = _context.Items;

            foreach (var item in items)
            {
                emptyItems.Add(new UsersItemModel
                {
                    UserId = userId,
                    ItemId = item.Id, // to powoduje że sie jebie, chociaż w data generatorze to działa
                    Count = 0
                });
            }

            return emptyItems;
        }

        public UserDetailsModel EmptyDetails(string userId)
        {
            var userDetails = new UserDetailsModel
            {
                UserId = userId,
                MatchesDrawn = 0,
                MatchesLost = 0,
                MatchesPlayed = 0,
                MatchesWon = 0,
                RankPoints = 0,
            };

            return userDetails;
        }
    }
}
