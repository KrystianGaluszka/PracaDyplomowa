using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faker;

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/DataGenerator")]
    [ApiController]

    public class DataGeneratorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataGeneratorController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("necessary")]
        public async Task<IActionResult> GenerateNecessaryData()
        {
            var stadiumList = new List<StadiumModel>();
            var sponsorList = new List<SponsorModel>();
            var itemList = new List<ItemModel>();
            var playersList = new List<PlayerModel>();

            for (int i = 0; i < 12; i++)
            {
                // other rarity
                var rarity = PlayerRarity.Common;
                switch (i)
                {
                    case 0:
                    case 6:
                        rarity = PlayerRarity.Common;
                        break;
                    case 1:
                    case 7:
                        rarity = PlayerRarity.Uncommon;
                        break;
                    case 2:
                    case 8:
                        rarity = PlayerRarity.Rare;
                        break;
                    case 3:
                    case 9:
                        rarity = PlayerRarity.Epic;
                        break;
                    case 4:
                    case 10:
                        rarity = PlayerRarity.Masterwork;
                        break;
                    case 5:
                    case 11:
                        rarity = PlayerRarity.Legendary;
                        break;
                    default:
                        rarity = PlayerRarity.Common;
                        break;
                }


                stadiumList.Add(new StadiumModel
                {
                    Name = Faker.Address.CitySuffix(),
                    SeatsCapacity = Faker.RandomNumber.Next(50, 10000),
                    IncomePerViewer = Faker.RandomNumber.Next(10, 250),
                    Price = Faker.RandomNumber.Next(150, 50000),
                });
                sponsorList.Add(new SponsorModel
                {
                    Name = Faker.Name.Last(),
                    MatchPrize = Faker.RandomNumber.Next(50, 10000),
                    WinPrize = Faker.RandomNumber.Next(50, 10000),
                    TitlePrize = Faker.RandomNumber.Next(50, 10000),
                });
                playersList.Add(new PlayerModel
                {
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Club = Faker.Company.Name(),
                    Country = Faker.Country.Name(),
                    Height = 150 + i * 2,
                    Rarity = rarity,
                    League = Faker.Address.CityPrefix(),
                    Level = Faker.RandomNumber.Next(1, 99),
                    Salary = Faker.RandomNumber.Next(1000, 1000000),
                    Weight = 50 + i * 2,
                });
            }

            if (!_context.Items.Any())
            {
                itemList.Add(new ItemModel { Name = "Bandage", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Med-Kit", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Contracts", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "XP-Boost", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Common chest", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Uncommon chest", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Rare chest", ImagePath = "players.jpg" });
                itemList.Add(new ItemModel { Name = "Epic chest", ImagePath = "players.jpg" });

                _context.Items.AddRange(itemList);
            }

            _context.Players.AddRange(playersList);
            _context.Stadiums.AddRange(stadiumList);
            _context.Sponsors.AddRange(sponsorList);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("fullUser")]
        public async Task<IActionResult> GenerateUserWithAllData()
        {
            var userId = "admin";
            var userDetails = new UserDetailsModel
            {
                UserId = userId,
                MatchesDrawn = 0,
                MatchesLost = 0,
                MatchesPlayed = 0,
                MatchesWon = 0,
                RankPoints = 0
            };

            var items = _context.Items;
            var emptyItems = new List<UsersItemModel>();

            foreach (var item in items)
            {
                emptyItems.Add(new UsersItemModel
                {
                    Count = 0,
                    ItemId = item.Id,
                    UserId = userId,
                });
            }
            var notifs = new List<NotificationModel>();
            for (int i = 0; i < 3; i++)
            {
                notifs.Add(new NotificationModel
                {
                    Receiver = userId,
                    Content = $"SAMPLE MESSAGE hakhf aklj hsr kjlahrejkl harkljas hfk jla hfkja  shnjkfh aslkjfhas {i}",
                    Topic = $"sample topic {i}",
                    UserId = userId,
                    CreateDate = DateTime.Now,
                    IconPath = "blank.png",
                    IsRead = false,
                });

            }

            var players = new List<UsersPlayerModel>();
            for (int i = 1; i <= 3; i++)
            {
                players.Add(new UsersPlayerModel
                {
                    Condition = 1,
                    Contract = 25,
                    IsCaptain = false,
                    IsOnAuction = false,
                    Level = 13,
                    PlayerId = i,
                    Salary = 1000,
                    UserId = userId,
                });
            }

            var mHistory = new List<UsersMatchHistoryModel>();
            for (int i = 0; i < 3; i++)
            {
                mHistory.Add(new UsersMatchHistoryModel
                {
                    UserId = userId,
                    MatchDate = DateTime.Now,
                    OpponentClub = "opponent1",
                    OpponentScore = i,
                    UserClub = "user1",
                    UserScore = 2,
                });
            }


            var userModel = new UserModel
            {
                Id = userId,
                BirthDate = DateTime.Now,
                ClubName = "FC Łazy",
                Name = "Polisa Debet",
                Country = "Polnish",
                Email = "admin@admin.pl",
                Money = 10000,
                Password = "admin",
                UsersItems = emptyItems,
                UserDetail = userDetails,
                ProfilePicturePath = "blank-profile-picture.png",
                SponsorId = 2,
                StadiumId = 1,
                Notifications = notifs,
                UsersPlayers = players,
                UserMatchesHistory = mHistory,
            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("addnotification")]
        public async Task<IActionResult> AddNotification(string userId, int count)
        {
            var user = _context.Users.FirstOrDefault(x=> x.Id == userId);
            var notifications = _context.Notifications;
            var notificationList = (List<NotificationModel>)user.Notifications;
            if (user != null)
            {
                for (int i = 0; i < count; i++)
                {
                    notificationList.Add(new NotificationModel
                    {
                        UserId = userId,
                        IconPath = "blank.png",
                        Content = $"SIEMANO {i}ALSJDLAJD LAJSLKD {i}JAL JDALSKJ DLAK JDL{i}A JLAS K",
                        CreateDate = DateTime.Now,
                        IsRead = false,
                        Topic = $"SAMPLE topic hehehe {i}",
                        Receiver = $"ktoś nr{i + 1}"
                    });
                }
                notifications.AddRange(notificationList);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            else return BadRequest("error");
        }

        [HttpPost("users")]
        public async Task<ActionResult> GenerateUsers(int userCount)
        {

            var userList = new List<UserModel>();

            for (int i = 0; i < userCount; i++)
            {
                var userId = Guid.NewGuid().ToString();
                var userDetails = new UserDetailsModel
                {
                    UserId = userId,
                    MatchesDrawn = 0,
                    MatchesLost = 0,
                    MatchesPlayed = 0,
                    MatchesWon = 0,
                    RankPoints = 0
                };

                var items = _context.Items;
                var emptyItems = new List<UsersItemModel>();

                foreach (var item in items)
                {
                    emptyItems.Add(new UsersItemModel
                    {
                        Count = 0,
                        ItemId = item.Id,
                        UserId = userId,
                    });
                }

                userList.Add(new UserModel
                {
                    Id = userId,
                    BirthDate = DateTime.Now,
                    ClubName = Faker.Company.Name(),
                    Name = Faker.Name.Middle(),
                    Country = Faker.Country.Name(),
                    Email = $"{Faker.Name.First()}@{Faker.Company.Name()}.com ",
                    Money = 10000,
                    Password = "test",
                    UsersItems = emptyItems,
                    UserDetail = userDetails,
                });
            }

            _context.Users.AddRange(userList);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpPost]
        //public async Task<string> GenerateAdditionalData(int count)
        //{
        //    var usersItemList = new List<UsersItemModel>();
        //    var usersDetailList = new List<UserDetailsModel>();
        //    var usersMatchesHistoryList = new List<UsersMatchHistoryModel>();
        //    var usersPlayerList = new List<UsersPlayerModel>();
        //    var auctionList = new List<AuctionModel>();

        //    for (int i = 0; i < count; i++)
        //    {
                
        //    }

        //    _context.UsersItems.AddRange(usersItemList);
        //    _context.UsersDetails.AddRange(usersDetailList);
        //    _context.UsersMatchesHistory.AddRange(usersMatchesHistoryList);
        //    _context.UsersPlayers.AddRange(usersPlayerList);
        //    _context.Auctions.AddRange(auctionList);

        //    _context.SaveChanges();

        //    return "Gituwa2";
        //}
    }
}
