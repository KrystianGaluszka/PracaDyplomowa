using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.DeleteModels;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using Hangfire;
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

        public async Task<int> PostAuction(AuctionPostModel auctionPostModel)
        {
            var player = _context.UsersPlayers.Where(x => x.Id == auctionPostModel.UserPlayerId).FirstOrDefault();
            var auctionModel = new AuctionModel 
            {
                Bid = auctionPostModel.Bid,
                Price = auctionPostModel.Price,
                UserId = auctionPostModel.UserId,
                UserPlayerId = auctionPostModel.UserPlayerId,
                Hours = 24,
                Minutes = 0,
            };
            player.UsersPlayerState.IsOnAuction = true;
            player.UsersPlayerState.IsPlaying = false;
            player.UsersPlayerState.IsOnBench = false;
            player.UsersPlayerState.IsCaptain = false;

            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            var auctionId = _context.Auctions.Where(x => x.UserId == auctionModel.UserId).OrderBy(x => x.Id).LastOrDefault().Id;

            return auctionId;
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

        public async Task<string> BuyPlayer(BuyFromAuctionPutModel buyFromAuction)
        {
            var auction = _context.Auctions.FirstOrDefault(x => x.Id == buyFromAuction.AuctionId);
            var bgTask = _context.BackgroundTasks.FirstOrDefault(x => x.TaskName == $"{auction.UserPlayerId}-{auction.UserId}-auction");
            var buyUser = _context.Users.FirstOrDefault(x => x.Id == buyFromAuction.UserId);

            string GetRank(int rankPoints)
            {
                if (rankPoints >= 1 && rankPoints <= 600) return "Bronze";
                else if (rankPoints >= 601 && rankPoints <= 1200) return "Silver";
                else if (rankPoints >= 1201 && rankPoints <= 1800) return "Gold";
                else if (rankPoints >= 1801 && rankPoints <= 2400) return "Platinum";
                else if (rankPoints >= 2401 && rankPoints <= 3600) return "Diamond";
                else if (rankPoints >= 3001 && rankPoints <= 3200) return "Champion";
                else return "Grand Champion";
            }

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
                    boughtPlayer.League = GetRank(buyUser.UserDetail.RankPoints);
                    boughtPlayer.Club = buyUser.ClubName;

                    BackgroundJob.Delete(bgTask.JobId);
                    _context.BackgroundTasks.Remove(bgTask);

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
