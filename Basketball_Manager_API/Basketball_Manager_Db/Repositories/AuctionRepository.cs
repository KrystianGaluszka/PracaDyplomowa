using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuctionViewModel>> GetAllAuctions()
        {
            var auctions = await _context.Auctions.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var auctionsModel = mapper.Map<List<AuctionModel>, List<AuctionViewModel>>(auctions);

            return auctionsModel;
        }

        public async Task<AuctionViewModel> GetAuction(int id)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var auctionModel = mapper.Map<AuctionModel, AuctionViewModel>(auction);

            return auctionModel;
        }
        public async Task<AuctionModel> PostAuction(AuctionPostModel auctionPostModel)
        {
            var player = _context.UsersPlayers.Where(x => x.Id == auctionPostModel.UserPlayerId).FirstOrDefault();
            var mapper = new Mapper(MapperConfig());

            var auctionModel = mapper.Map<AuctionPostModel, AuctionModel>(auctionPostModel);
            auctionModel.UsersPlayer = player;

            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            return auctionModel;
        }
    }
}
