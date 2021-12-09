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

        [HttpPost]
        public async Task<string> GenerateData(int count)
        {
            // must be
            var playersList = new List<PlayerModel>();
            var stadiumList = new List<StadiumModel>();
            var sponsorList = new List<SponsorModel>();
            var itemList = new List<ItemModel>();
            // additional data for tests
            var userList = new List<UserModel>();
            var usersItemList = new List<UsersItemModel>();
            var usersDetailList = new List<UserDetailsModel>();
            var usersMatchesHistoryList = new List<UsersMatchHistoryModel>();
            var usersPlayerList = new List<UsersPlayerModel>();
            var auctionList = new List<AuctionModel>();

            for (int i = 0; i < count; i++)
            {
                playersList.Add(new PlayerModel
                {
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Club = Faker.Company.Name(),
                    Country = Faker.Country.Name(),
                    Height = 150 + i * 2,
                    IsLegend = false,
                    League = Faker.Address.CityPrefix(),
                    Level = Faker.RandomNumber.Next(1, 99),
                    Salary = Faker.RandomNumber.Next(1000, 1000000),
                    Weight = 50 + i * 2,
                });
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
            }
            itemList.Add(new ItemModel { Name = "Bandage" });
            itemList.Add(new ItemModel { Name = "Med-Kit" });
            itemList.Add(new ItemModel { Name = "Contracts" });
            itemList.Add(new ItemModel { Name = "XP-Boost" });

            _context.Players.AddRange(playersList);
            _context.Stadiums.AddRange(stadiumList);
            _context.Sponsors.AddRange(sponsorList);
            _context.Items.AddRange(itemList);

            //_context.Users.AddRange(userList);
            //_context.UsersItems.AddRange(usersItemList);
            //_context.UsersDetails.AddRange(usersDetailList);
            //_context.UsersMatchesHistory.AddRange(usersMatchesHistoryList);
            //_context.UsersPlayers.AddRange(usersPlayerList);
            //_context.Auctions.AddRange(auctionList);

            _context.SaveChanges();

            return "Gituwa";
        }
    }
}
