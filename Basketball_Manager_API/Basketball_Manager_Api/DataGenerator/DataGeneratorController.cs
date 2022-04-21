using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faker;

namespace Basketball_Manager_Api.DataGenerator
{
    [Route("api/DataGenerator")]
    [ApiController]

    public class DataGeneratorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected string basePath = "https://localhost:44326/images/";

        public DataGeneratorController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("necessary")]
        public async Task<IActionResult> GenerateNecessaryData()
        {
            Random rnd = new Random();
            var sponsorList = new List<SponsorsModel>();
            var itemList = new List<ItemModel>();
            var playersList = new List<PlayerModel>();
            var rankList = new List<RankRequirementModel>();


            for (int i = 0; i < 6; i++)
            {
                // other rarity
                var rarity = PlayerRarity.Common;
                switch (i)
                {
                case 1:
                    rarity = PlayerRarity.Uncommon;
                    break;
                case 2:
                    rarity = PlayerRarity.Rare;
                    break;
                case 3:
                    rarity = PlayerRarity.Epic;
                    break;
                case 4:
                    rarity = PlayerRarity.Masterwork;
                    break;
                case 5:
                    rarity = PlayerRarity.Legendary;
                    break;
                default:
                    rarity = PlayerRarity.Common;
                    break;
                }
                sponsorList.Add(new SponsorsModel
                {
                    Name = Faker.Name.Last(),
                    MatchPrize = Faker.RandomNumber.Next(50, 10000),
                    WinPrize = Faker.RandomNumber.Next(50, 10000),
                    TitlePrize = Faker.RandomNumber.Next(50, 10000),
                    RequiredLevel = Faker.RandomNumber.Next(5,497),
                });

                for (int j = 0; j < 5; j++)
                {
                    var playerPosition = "PG";
                    switch (j)
                    {
                    case 1:
                        playerPosition = "SG";
                        break;
                    case 2:
                        playerPosition = "SF";
                        break;
                    case 3:
                        playerPosition = "PF";
                        break;
                    case 4:
                        playerPosition = "C";
                        break;
                    default:
                        playerPosition = "PG";
                        break;
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        playersList.Add(new PlayerModel
                        {
                            Name = Faker.Name.First(),
                            Surname = Faker.Name.Last(),
                            Country = Faker.Country.Name(),
                            Height = 150 + j * 2,
                            Rarity = rarity,
                            Level = Faker.RandomNumber.Next(1, 99),
                            Salary = Faker.RandomNumber.Next(1000, 1000000),
                            Weight = 50 + j * 2,
                            PicturePath = basePath + "players-icon.png",
                            Position = playerPosition,
                        });
                    }
                    
                }
            }

            var rankPointsBase = 200;
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    switch(i)
                    {
                        case 1:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Bronze {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                        case 2:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Silver {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                        case 3:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Gold {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                        case 4:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Platinum {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                        case 5:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Diamond {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                        case 6:
                            rankList.Add(new RankRequirementModel
                            {
                                RankName = $"Champion {j}",
                                PointsRequired = rankPointsBase - 199,
                                PointsLimit = rankPointsBase,
                                IconPath = basePath + "rankIcons/chevron.png"
                            });
                            break;
                    }
                    rankPointsBase += 200;
                }
                if (i == 6)
                {
                    rankList.Add(new RankRequirementModel
                    {
                        RankName = $"Grand Champion",
                        PointsRequired = rankPointsBase - 199,
                        PointsLimit = 9999999,
                        IconPath = basePath + "rankIcons/chevron.png"
                    });
                }
            }

            if (!_context.Items.Any())
            {
                itemList.Add(new ItemModel { Name = "Med-Kit", IconPath = basePath + "shopIcons/med-kit.png", Price = 100,
                    Description = "Remove player's injury"});
                itemList.Add(new ItemModel { Name = "Contracts", IconPath = basePath + "shopIcons/contracts.png", Price = 100,
                    Description = "Extend player's contract duration"});
                itemList.Add(new ItemModel { Name = "XP-Boost", IconPath = basePath + "shopIcons/xp-boost.png", Price = 100 , 
                    Description = "Gives player + 15% experience from all sources" });
                itemList.Add(new ItemModel { Name = "Common chest", IconPath = basePath + "shopIcons/chest-common.png", Price = 100 ,
                    Description = "Chest with 3 random common players" });
                itemList.Add(new ItemModel { Name = "Uncommon chest", IconPath = basePath + "shopIcons/chest-uncommon.png", Price = 200,
                    Description = "Chest with 2 random common and 1 uncommon players"
                });
                itemList.Add(new ItemModel { Name = "Rare chest", IconPath = basePath + "shopIcons/chest-rare.png", Price = 500,
                    Description = "Chest with 3 random uncommon players. 50% chance to get rare player"});
                itemList.Add(new ItemModel { Name = "Epic chest", IconPath = basePath + "shopIcons/chest-epic.png", Price = 1000,
                    Description = "Chest with at least uncommon players. 50% chance to get rare player"
                });
                itemList.Add(new ItemModel { Name = "Masterwork chest", IconPath = basePath + "shopIcons/chest-masterwork.png", Price = 5000,
                    Description = "Chest with at least rare players. 50% chance to get epic player"
                });
                itemList.Add(new ItemModel { Name = "Legendary chest", IconPath = basePath + "shopIcons/chest-legendary.png", Price = 15000,
                    Description = "Chest with at least epic players and 1 legendary player"
                });

                _context.Items.AddRange(itemList);
            }

            _context.Players.AddRange(playersList);
            _context.Sponsors.AddRange(sponsorList);
            _context.RankRequirements.AddRange(rankList);

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
                MatchesDrawn = 3,
                MatchesLost = 1,
                MatchesPlayed = 9,
                MatchesWon = 5,
                RankPoints = 193,
                LastSeasonRank = "None",
                AllMatchesDrawn = 5,
                AllMatchesLost = 7,
                AllMatchesWon = 16,
                AllMatchesPlayed = 28,
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
                    Content = $"SAMPLE MESSAGE hakhf aklj hsr kjlahrejkl harkljas hfk jla hfkja  shnjkfh aslkjfhas {i}",
                    Topic = $"sample topic {i}",
                    UserId = userId,
                    CreateDate = DateTime.Now,
                    IconPath = basePath + "notificationsIcons/notification-bell.png",
                    IsRead = false,
                });

            }


            var players = new List<UsersPlayerModel>();
            for (int i = 1; i <= 20; i++)
            {
                var playing = false;
                if (i <= 5) playing = true;

                var playerState = new UsersPlayerStateModel
                {
                    IsCaptain = false,
                    IsOnAuction = false,
                    IsOnBench = false,
                    IsPlaying = playing,
                    IsBoosted = false,
                    IsInjured = false
                };

                var playerPoints = new UsersPlayerPointsModel
                {
                    OnePoints = 0,
                    TwoPoints = 0,
                    ThreePoints = 0,
                    AllOnePoints = 0,
                    AllTwoPoints = 0,
                    AllThreePoints = 0
                };

                players.Add(new UsersPlayerModel
                {
                    Condition = 100,
                    Contract = 25,
                    Level = 13,
                    PlayerId = i,
                    Salary = 1000,
                    UserId = userId,
                    RequiredExperience = 1000,
                    Experience = 0,
                    Score = 0,
                    UsersPlayerState = playerState,
                    UsersPlayerPoints  = playerPoints,
                    TrainingType = Training.None,
                    Club = "Fc Łazy",
                    League = "Bronze I"
                });
            }

            var mHistory = new List<UsersMatchHistoryModel>();
            for (int i = 0; i < 3; i++)
            {
                mHistory.Add(new UsersMatchHistoryModel
                {
                    UserId = userId,
                    MatchDate = DateTime.Now,
                    User2Club = "opponent1",
                    User2Score = i,
                    UserClub = "user1",
                    UserScore = 2,
                    Mvp = "Super typ",
                    IsDone = true,
                });
            }

            var stadium = new StadiumModel
            {
                Name = "Admin's Stadium",
                UserId = userId,
                SeatsCapacity = 150,
                IncomePerViewer = 15,
                Level = 1,
                Price = 10000,
            };

            var sponsor = new UsersSponsorModel
            {
                SponsorId = 2,
                UserId = userId,
                MatchPrizeCount = 0,
                MatchPrizeTotality = 0,
                TitlePrizeCount = 0,
                TitlePrizeTotality = 0,
                WinPrizeCount = 0,
                WinPrizeTotality = 0,
            };

            var userModel = new UserModel
            {
                Id = userId,
                BirthDate = DateTime.Now,
                ClubName = "FC Łazy",
                Name = "Polisa Debet",
                Country = "Polnish",
                Email = "admin@admin.pl",
                Money = 1000000,
                Password = "admin",
                UsersItems = emptyItems,
                UserDetail = userDetails,
                ProfilePicturePath = basePath + "profilePics/blank.png",
                UserSponsor = sponsor,
                Stadium = stadium,
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
            var notificationList = new List<NotificationModel>();
            if (user != null)
            {
                for (int i = 0; i < count; i++)
                {
                    notificationList.Add(new NotificationModel
                    {
                        UserId = userId,
                        IconPath = basePath + "notificationsIcons/notification-bell.png",
                        Content = $"SIEMANO {i}ALSJDLAJD LAJSLKD {i}JAL JDALSKJ DLAK JDL{i}A JLAS K",
                        CreateDate = DateTime.Now,
                        IsRead = false,
                        Topic = $"SAMPLE topic hehehe {i}",
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

                var userName = Faker.Name.Middle();

                var stadium = new StadiumModel
                {
                    Name = $"{userName}'s Stadium",
                    UserId = userId,
                    SeatsCapacity = 150,
                    IncomePerViewer = 15,
                    Level = 1,
                    Price = 10000,
                };
                userList.Add(new UserModel
                {
                    Id = userId,
                    BirthDate = DateTime.Now,
                    ClubName = Faker.Company.Name(),
                    Name = userName,
                    Country = Faker.Country.Name(),
                    Email = $"{Faker.Name.First()}@{Faker.Company.Name()}.com ",
                    Money = 100000,
                    Password = "test",
                    UsersItems = emptyItems,
                    UserDetail = userDetails,
                    ProfilePicturePath = basePath + "profilePics/blank.png",
                    Stadium = stadium,
                });
            }

            _context.Users.AddRange(userList);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
