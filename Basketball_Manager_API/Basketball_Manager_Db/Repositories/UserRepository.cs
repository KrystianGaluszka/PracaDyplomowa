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
using Hangfire;

namespace Basketball_Manager_Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService_Db _jwtService;
        protected string basePath = "https://localhost:44326/images/profilePics/";

        public UserRepository(JwtService_Db jwtService, ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<IEnumerable<RankRequirementViewModel>> GetRankTable()
        {
            var rankTable = await _context.RankRequirements.ToListAsync();
            var config = MapperConfig();
            var mapper = new Mapper(config);

            var rankTableModel = mapper.Map<List<RankRequirementModel>, List<RankRequirementViewModel>>(rankTable);

            return rankTableModel;
        }

        public async Task<string> PostAccountCreate(RegisterPostModel registerPostModel)
        {
            var id = Guid.NewGuid().ToString();
            var emails = _context.Users.Select(x => x.Email);

            if (emails.Contains(registerPostModel.Email))
            {
                return null;
            }
            var players = new List<UsersPlayerModel>();
            for (int i = 0; i < 5; i++)
            {
                var rnd = new Random();
                var position = "C";
                if (i == 1) position = "PG";
                else if (i == 2) position = "SG";
                else if (i == 3) position = "SF";
                else if (i == 4) position = "PF";

                var commonPlayers = _context.Players.Where(x=> x.Rarity.Equals(PlayerRarity.Common));
                var commonPositionPlayer = commonPlayers.Where(x => x.Position == position);

                var rndPlayer = rnd.Next(1, commonPositionPlayer.Count());
                var player = commonPositionPlayer.Skip(rndPlayer).FirstOrDefault();

                var playerState = new UsersPlayerStateModel 
                {
                    IsCaptain = false,
                    IsOnAuction = false,
                    IsOnBench = false,
                    IsPlaying = true,
                    IsBoosted = false,
                    IsInjured = false,
                };

                var playerPoints = new UsersPlayerPointsModel
                {
                    OnePoints = 0,
                    TwoPoints = 0,
                    ThreePoints = 0,
                    AllOnePoints = 0,
                    AllTwoPoints = 0,
                    AllThreePoints = 0,
                };
                players.Add(new UsersPlayerModel
                {
                    PlayerId = player.Id,
                    UserId = id,
                    Condition = 100,
                    Contract = 25,
                    Salary = player.Salary,
                    Level = player.Level,
                    Experience = 0,
                    RequiredExperience = player.Level * 100,
                    UsersPlayerPoints = playerPoints,
                    UsersPlayerState = playerState,
                    TrainingType = Training.None,
                    Club = registerPostModel.ClubName,
                    League = "Bronze"
                });
            }

            var captain = players.MaxBy(x => x.Level);
            captain.UsersPlayerState.IsCaptain = true;
            
            var config = MapperConfig();
            var mapper = new Mapper(config);

            var userModel = mapper.Map<RegisterPostModel, UserModel>(registerPostModel);
            userModel.Id = id;
            userModel.Money = 25000;
            userModel.UsersItems = EmptyItems(id);
            userModel.UserDetail = EmptyDetails(id);
            userModel.ProfilePicturePath = basePath + "blank.png";
            userModel.UsersPlayers = players;
            userModel.Stadium = new StadiumModel
            {
                Name = $"{registerPostModel.Name}'s Stadium",
                UserId = id,
                SeatsCapacity = 150,
                IncomePerViewer = 15,
                Level = 1,
                Price = 10000,
            };
            userModel.UserSponsor = new UsersSponsorModel()
            {
                MatchPrizeCount = 0,
                TitlePrizeCount = 0,
                WinPrizeCount = 0,
                MatchPrizeTotality = 0,
                TitlePrizeTotality = 0,
                WinPrizeTotality = 0,
                UserId = id,
            };

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
                user.ProfilePicturePath = userPutModel.ProfilePicturePath != "" ? basePath + userPutModel.ProfilePicturePath : user.ProfilePicturePath;
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
                    ItemId = item.Id,
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
                RankPoints = 1,
                AllMatchesDrawn = 0,
                AllMatchesLost = 0,
                AllMatchesPlayed = 0,
                AllMatchesWon = 0,
                LastSeasonRank = "None",
            };

            return userDetails;
        }
    }
}
