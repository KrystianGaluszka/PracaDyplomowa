using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basketball_Manager_Api.HangfireBackgroundService
{
    public class AuctionRemainingTime
    {
        private readonly ApplicationDbContext _context;

        public AuctionRemainingTime(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CountDown(CancellationToken token, int auctionId)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1), token);
                    
                    var auction = _context.Auctions.FirstOrDefault(x => x.Id == auctionId);
                    var bgTask = _context.BackgroundTasks.FirstOrDefault(x => x.TaskName == $"{auction.UserPlayerId}-{auction.UserId}-auction");
                    var player = _context.UsersPlayers.FirstOrDefault(x => x.Id == auction.UserPlayerId);

                    if (auction.Minutes == 0)
                    {
                        auction.Minutes = 59;
                        auction.Hours -= 1;
                    }
                    else if (auction.Hours == 0 && auction.Minutes == 0)
                    {
                        if (auction.BidUserId != null)
                        {
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

                            var bidUser = _context.Users.FirstOrDefault(x => x.Id == auction.BidUserId);

                            _context.Notifications.Add(new NotificationModel
                            {
                                Topic = "Auction",
                                Content = $"Player {player.Player.Name} {player.Player.Surname} has been sold for {auction.Bid}$.",
                                IconPath = "https://localhost:44326/images/notificationsIcons/notification-bell.png",
                                IsRead = false,
                                CreateDate = DateTime.Now,
                                UserId = auction.UserId,
                            });

                            player.UserId = auction.BidUserId;
                            player.League = GetRank(bidUser.UserDetail.RankPoints);
                            player.Club = bidUser.ClubName;
                            player.UsersPlayerState.IsCaptain = false;
                            player.UsersPlayerState.IsOnBench = false;
                            player.UsersPlayerState.IsPlaying = false;
                            player.UsersPlayerState.IsBoosted = false;
                            player.Contract = 25;
                        }
                        else
                        {
                            _context.Notifications.Add(new NotificationModel
                            {
                                Topic = "Auction",
                                Content = $"Player {player.Player.Name} {player.Player.Surname} has not been sold.",
                                IconPath = "https://localhost:44326/images/notificationsIcons/notification-bell.png",
                                IsRead = false,
                                CreateDate = DateTime.Now,
                                UserId = auction.UserId,
                            });
                        }
                       
                        _context.Auctions.Remove(auction);
                        _context.BackgroundTasks.Remove(bgTask);
                        player.UsersPlayerState.IsOnAuction = false;

                        await _context.SaveChangesAsync();
                        return;

                    }
                    else
                    {
                        auction.Minutes -= 1;
                    }
                }
            }
        }
    }
}
