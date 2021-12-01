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
            var player = _context.UsersPlayers.Where(x => x.Id == auctionPostModel.AuctionDetailsModel.UserPlayerId).FirstOrDefault();
            var auctionDetailsModel = new AuctionDetailsModel
            {
                UserId = auctionPostModel.AuctionDetailsModel.UserId,
                UsersPlayer = player,
                Bid = 1000,
                Price = 2500,
            };

            _context.AuctionDetails.Add(auctionDetailsModel);
            _context.SaveChanges();

            var auctionDetails = _context.AuctionDetails.OrderByDescending(x => x.Id).FirstOrDefault();
            var auctionModel = new AuctionModel
            {
                Club = auctionPostModel.AuctionModel.Club,
                Condition = auctionPostModel.AuctionModel.Condition,
                Country = auctionPostModel.AuctionModel.Country,
                Height = auctionPostModel.AuctionModel.Height,
                League = auctionPostModel.AuctionModel.League,
                Level = auctionPostModel.AuctionModel.Level,
                Name = auctionPostModel.AuctionModel.Name,
                Salary = auctionPostModel.AuctionModel.Salary,
                Surname = auctionPostModel.AuctionModel.Surname,
                Weight = auctionPostModel.AuctionModel.Weight,
                AuctionDetails = auctionDetails
            };
            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            return await _context.Auctions.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
