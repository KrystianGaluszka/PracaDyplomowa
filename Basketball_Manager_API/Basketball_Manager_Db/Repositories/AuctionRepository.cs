using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuctionModel>> GetAllAuctions()
        {
            return await _context.Auctions.ToListAsync();
        }

        public async Task<AuctionModel> GetAuction(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AuctionModel> PostAuction(AuctionPostModel auctionPostModel)
        {
            var player = _context.UsersPlayers.Where(x => x.Id == auctionPostModel.UserPlayerId).FirstOrDefault();

            var auctions = _context.Auctions.OrderByDescending(x => x.Id).FirstOrDefault();
            var auctionModel = new AuctionModel
            {
                UserId = auctionPostModel.UserId,
                UsersPlayer = player,
                Bid = 1000,
                Price = 2500,
                Club = auctionPostModel.Club,
                Condition = auctionPostModel.Condition,
                Country = auctionPostModel.Country,
                Height = auctionPostModel.Height,
                League = auctionPostModel.League,
                Level = auctionPostModel.Level,
                Name = auctionPostModel.Name,
                Salary = auctionPostModel.Salary,
                Surname = auctionPostModel.Surname,
                Weight = auctionPostModel.Weight,
            };
            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            return await _context.Auctions.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
