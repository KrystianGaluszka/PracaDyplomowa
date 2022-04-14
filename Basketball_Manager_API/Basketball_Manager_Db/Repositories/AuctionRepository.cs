using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.DeleteModels;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
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
        public async Task<string> PostAuction(AuctionPostModel auctionPostModel)
        {
            var player = _context.UsersPlayers.Where(x => x.Id == auctionPostModel.UserPlayerId).FirstOrDefault();
            var auctionModel = new AuctionModel 
            {
                Bid = auctionPostModel.Bid,
                Price = auctionPostModel.Price,
                UserId = auctionPostModel.UserId,
                UserPlayerId = auctionPostModel.UserPlayerId,
            };
            player.UsersPlayerState.IsOnAuction = true;
            player.UsersPlayerState.IsPlaying = false;
            player.UsersPlayerState.IsOnBench = false;
            player.UsersPlayerState.IsCaptain = false;

            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            return "success";
        }

        public async Task<string> BidPlayer(BidFromAuctionPutModel bidFromAuction)
        {
            var auction = _context.Auctions.FirstOrDefault(x => x.Id == bidFromAuction.AuctionId);
            var user = _context.Users.FirstOrDefault(x => x.Id == bidFromAuction.UserId);
            if (auction != null && user != null)
            {
                auction.Bid = bidFromAuction.Bid;
                auction.BidUserId = bidFromAuction.UserId;

                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }

        public async Task<string> BidEnd(BidFromAuctionPutModel bidFromAuction)
        {
            var auction = _context.Auctions.FirstOrDefault(x => x.Id == bidFromAuction.AuctionId);
            var buyUser = _context.Users.FirstOrDefault(x => x.Id == bidFromAuction.UserId);
            if (auction != null && buyUser != null)
            {
                var sellUser = _context.Users.FirstOrDefault(x => x.Id == auction.UserId);
                var boughtPlayer = _context.UsersPlayers.FirstOrDefault(x => x.Id == auction.UserPlayerId);
                if (boughtPlayer != null && sellUser != null)
                {
                    sellUser.Money += auction.Bid;
                    buyUser.Money -= auction.Bid;
                    boughtPlayer.UserId = buyUser.Id;
                    boughtPlayer.Contract = 25;
                    boughtPlayer.UsersPlayerState.IsCaptain = false;
                    boughtPlayer.UsersPlayerState.IsInjured = false;
                    boughtPlayer.UsersPlayerState.IsOnAuction = false;
                    boughtPlayer.UsersPlayerState.IsOnBench = false;
                    boughtPlayer.UsersPlayerState.IsPlaying = false;
                    boughtPlayer.UsersPlayerState.IsBoosted = false;
                    boughtPlayer.Condition = 100;

                    await _context.SaveChangesAsync();

                    return "success";
                }
                else return "error";
            }
            else return "error";
        }
        public async Task<string> BuyPlayer(BuyFromAuctionPutModel buyFromAuction)
        {
            var auction = _context.Auctions.FirstOrDefault(x => x.Id == buyFromAuction.AuctionId);
            var buyUser = _context.Users.FirstOrDefault(x => x.Id == buyFromAuction.UserId);
            if (auction != null && buyUser != null)
            {
                var sellUser = _context.Users.FirstOrDefault(x =>x.Id == auction.UserId);
                var boughtPlayer = _context.UsersPlayers.FirstOrDefault(x => x.Id == auction.UserPlayerId);
                if (boughtPlayer != null && sellUser != null)
                {
                    sellUser.Money += auction.Price;
                    buyUser.Money -= auction.Price;
                    boughtPlayer.UserId = buyUser.Id;
                    boughtPlayer.Contract = 25;
                    boughtPlayer.UsersPlayerState.IsCaptain = false;
                    boughtPlayer.UsersPlayerState.IsInjured = false;
                    boughtPlayer.UsersPlayerState.IsOnAuction = false;
                    boughtPlayer.UsersPlayerState.IsOnBench = false;
                    boughtPlayer.UsersPlayerState.IsPlaying = false;
                    boughtPlayer.UsersPlayerState.IsBoosted = false;
                    boughtPlayer.Condition = 100;

                    await _context.SaveChangesAsync();

                    return "success";
                }
                else return "error";
            }
            else return "error";
        }

        public async Task<string> DeleteAfterPurchase(int auctionId)
        {
            var auction = _context.Auctions.FirstOrDefault(x => x.Id == auctionId);
            if (auction != null)
            {
                _context.Auctions.Remove(auction);

                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }

        public async Task<string> QuickSell(QuickSellDeleteModel quickSellDeleteModel)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == quickSellDeleteModel.UserId);

            if (quickSellDeleteModel.UserPlayerIds.Count() != 0)
            {
                foreach (var playerId in quickSellDeleteModel.UserPlayerIds)
                {
                    var player = _context.UsersPlayers.FirstOrDefault(x => x.Id == playerId);
                    var rarityMultiplier = 1.0;

                    switch (player.Player.Rarity)
                    {
                        case PlayerRarity.Uncommon:
                            rarityMultiplier = 1.2;
                            break;
                        case PlayerRarity.Rare:
                            rarityMultiplier = 1.5;
                            break;
                        case PlayerRarity.Epic:
                            rarityMultiplier = 2;
                            break;
                        case PlayerRarity.Masterwork:
                            rarityMultiplier = 3;
                            break;
                        case PlayerRarity.Legendary:
                            rarityMultiplier = 5;
                            break;
                    }

                    var playerValue = (player.Level * 100) * rarityMultiplier;

                    if (user != null && player != null)
                    {
                        _context.UsersPlayers.Remove(player);

                        await _context.SaveChangesAsync();

                        user.Money += playerValue;

                        await _context.SaveChangesAsync();

                    }
                    else return "error";
                }
                return "success";
            }
            else return "empty_array";
        }

        public async Task<string> RemovePlayer(RemoveFromAuctionDeleteModel removeFromAuction)
        {

            if (removeFromAuction.UserPlayerIds.Count() != 0)
            {
                foreach (var userPlayerId in removeFromAuction.UserPlayerIds)
                {
                    var auction = _context.Auctions.FirstOrDefault(x => x.UserPlayerId == userPlayerId);
                    var userPLayer = _context.UsersPlayers.FirstOrDefault(x => x.Id == userPlayerId);

                    if (userPLayer != null && auction != null)
                    {
                        userPLayer.UsersPlayerState.IsOnAuction = false;

                        await _context.SaveChangesAsync();

                        _context.Auctions.Remove(auction);

                        await _context.SaveChangesAsync();
                    }
                    else return "error";

                }
                return "success";
            }
            else return "empty_array";
        }
    }
}
