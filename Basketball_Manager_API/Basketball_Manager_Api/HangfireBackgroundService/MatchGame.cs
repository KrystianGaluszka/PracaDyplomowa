using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basketball_Manager_Api.HangfireBackgroundService
{
    public class MatchGame
    {
        private readonly ApplicationDbContext _context;

        public MatchGame(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Match(CancellationToken token, string userId, string opponentId)
        {
            // setting players and data in db
            var user1 = _context.Users.FirstOrDefault(x => x.Id == userId);
            var user2 = _context.Users.FirstOrDefault(x => x.Id == opponentId);
            var userPlayers = _context.Users.FirstOrDefault(x=> x.Id == userId).UsersPlayers.Where(x => x.UsersPlayerState.IsPlaying).ToList();
            var opponentPlayers = _context.Users.FirstOrDefault(x=> x.Id == opponentId).UsersPlayers.Where(x => x.UsersPlayerState.IsPlaying).ToList();

            await Task.Delay(TimeSpan.FromSeconds(3), token);

            //match started
            var match = _context.UsersMatchesHistory.Where(x => !x.IsDone).OrderBy(x => x.Id).LastOrDefault(x => x.UserId == userId || x.UserId == opponentId);
            var currentTask = _context.BackgroundTasks.Where(x => x.TaskName == "match").OrderBy(x => x.Id).LastOrDefault(x => x.UserId == userId || x.UserId == opponentId);
            currentTask.IsStarted = true;

            await _context.SaveChangesAsync();

            // setting data for a match
            var entireCounter1 = 0;
            var entireCounter2 = 0;

            var playersPointsList = new Dictionary<int, int>();
            var allPlayers = userPlayers.Concat(opponentPlayers);
            foreach (var player in allPlayers)
            {
                playersPointsList.Add(player.Id, 0);
            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 1; j <= 60; j++)
                {
                    switch (j)
                    {
                        case 1:
                        case 3:
                        case 6:
                        case 9:
                        case 12:
                        case 15:
                        case 18:
                        case 21:
                        case 24:
                        case 27:
                        case 33:
                        case 36:
                        case 39:
                        case 42:
                        case 45:
                        case 48:
                        case 51:
                        case 54:
                        case 57:
                        case 60:
                            var rnd = new Random();
                            var userPlayer = userPlayers.Skip(rnd.Next(1, 5)).Take(1).First();
                            var user2Player = opponentPlayers.Skip(rnd.Next(1, 5)).Take(1).First();
                            var user1rarityPower = 1.0;
                            var user2rarityPower = 1.0;
                            switch (userPlayer.Player.Rarity)
                            {
                                case PlayerRarity.Uncommon:
                                    user1rarityPower = 1.1;
                                    break;
                                case PlayerRarity.Rare:
                                    user1rarityPower = 1.2;
                                    break;
                                case PlayerRarity.Epic:
                                    user1rarityPower = 1.3;
                                    break;
                                case PlayerRarity.Masterwork:
                                    user1rarityPower = 1.5;
                                    break;
                                case PlayerRarity.Legendary:
                                    user1rarityPower = 2;
                                    break;
                            }
                            switch (user2Player.Player.Rarity)
                            {
                                case PlayerRarity.Uncommon:
                                    user2rarityPower = 1.1;
                                    break;
                                case PlayerRarity.Rare:
                                    user2rarityPower = 1.2;
                                    break;
                                case PlayerRarity.Epic:
                                    user2rarityPower = 1.3;
                                    break;
                                case PlayerRarity.Masterwork:
                                    user2rarityPower = 1.5;
                                    break;
                                case PlayerRarity.Legendary:
                                    user2rarityPower = 2;
                                    break;
                            }

                            var user1Power = userPlayer.Level * (userPlayer.Condition / 100) * user1rarityPower;
                            if (userPlayer.UsersPlayerState.IsInjured)
                            {
                                user1Power /= 5;
                            }

                            var user2Power = user2Player.Level * (user2Player.Condition / 100) * user2rarityPower;
                            if (user2Player.UsersPlayerState.IsInjured)
                            {
                                user2Power /= 5;
                            }

                            var user1Percent = user1Power / (user1Power + user2Power);
                            var user2Percent = user2Power / (user1Power + user2Power);

                            var user1Probability = 1 - Math.Exp(-user1Percent / 4);
                            var user2Probability = 1 - Math.Exp(-user2Percent / 4);

                            if (user1Probability > rnd.NextDouble()) // % chance of getting 2 point
                            {
                                if (25 > rnd.Next(1, 101)) // 25 % chance of getting 1 point
                                {
                                    userPlayer.Score += 1;
                                    match.UserScore += 1;
                                    playersPointsList[userPlayer.Id] += 1;
                                    entireCounter1 += 1;
                                }
                                else if (65 > rnd.Next(1, 101)) // 65 % chance of getting 3 point
                                {
                                    userPlayer.Score += 3;
                                    match.UserScore += 3;
                                    playersPointsList[userPlayer.Id] += 3;
                                    entireCounter1 += 3;
                                }
                                else // getting 2 points
                                {
                                    userPlayer.Score += 2;
                                    match.UserScore += 2;
                                    playersPointsList[userPlayer.Id] += 2;
                                    entireCounter1 += 2;
                                }
                            }

                            if (user2Probability > rnd.NextDouble())
                            {
                                if (25 > rnd.Next(1, 101))
                                {
                                    user2Player.Score += 1;
                                    match.User2Score += 1;
                                    playersPointsList[user2Player.Id] += 1;
                                    entireCounter2 += 1;
                                }
                                else if (65 > rnd.Next(1, 101))
                                {
                                    user2Player.Score += 3;
                                    match.User2Score += 3;
                                    playersPointsList[user2Player.Id] += 3;
                                    //
                                    entireCounter2 += 3;
                                }
                                else
                                {
                                    user2Player.Score += 2;
                                    match.User2Score += 2;
                                    playersPointsList[user2Player.Id] += 2;
                                    entireCounter2 += 2;
                                }
                            }

                            //chance of getting injured after shoot (0.25%)
                            if (!userPlayer.UsersPlayerState.IsInjured)
                            {
                                if (1 > rnd.Next(1, 401))
                                {
                                    userPlayer.UsersPlayerState.IsInjured = true;

                                    var postModel = new
                                    {
                                        UserId = userId,
                                        Topic = "Player injured",
                                        Content = $"During the match {user1.ClubName} vs {user1.ClubName} player {userPlayer.Player.Name} {userPlayer.Player.Surname} has been injured.",
                                        IsRead = false,
                                        CreateDate = DateTime.Now,
                                        IconPath = "match-icon.png"
                                    };

                                    using (var httpClient = new HttpClient())
                                    {
                                        StringContent content = new StringContent(JsonConvert.SerializeObject(postModel), Encoding.UTF8, "application/json");

                                        using (var response = await httpClient.PostAsync("https://localhost:44326/api/Notification/create", content))
                                        {
                                            string apiResponse = await response.Content.ReadAsStringAsync();
                                        }
                                    }
                                }
                            }
                            if (!user2Player.UsersPlayerState.IsInjured)
                            {
                                if (1 > rnd.Next(1, 401))
                                {
                                    user2Player.UsersPlayerState.IsInjured = true;

                                    var postModel = new
                                    {
                                        UserId = opponentId,
                                        Topic = "Player injured",
                                        Content = $"During the match {user2.ClubName} vs {user2.ClubName} player {user2Player.Player.Name} {user2Player.Player.Surname} has been injured.",
                                        IsRead = false,
                                        CreateDate = DateTime.Now,
                                        IconPath = "match-icon.png"
                                    };

                                    using (var httpClient = new HttpClient())
                                    {
                                        StringContent content = new StringContent(JsonConvert.SerializeObject(postModel), Encoding.UTF8, "application/json");

                                        using (var response = await httpClient.PostAsync("https://localhost:44326/api/Notification/create", content))
                                        {
                                            string apiResponse = await response.Content.ReadAsStringAsync();
                                        }
                                    }
                                }
                            }

                            break;
                    }

                    if (match.SecondsLeft != 0 || match.MinutesLeft != 0)
                    {
                        if (match.SecondsLeft == 0)
                        {
                            match.MinutesLeft -= 1;
                            match.SecondsLeft = 59;
                        }
                        else match.SecondsLeft -= 1;
                    }


                    await _context.SaveChangesAsync();
                    await Task.Delay(TimeSpan.FromSeconds(1), token);
                }
            }

            // setting mvp player
            var mvpPlayerId = playersPointsList.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            var mvpPlayer = _context.UsersPlayers.FirstOrDefault(x => x.Id == mvpPlayerId);
            var mvpPoints = playersPointsList.GetValueOrDefault(mvpPlayerId);
            var mvpPlayerName = $"{mvpPlayer.Player.Name} {mvpPlayer.Player.Surname}";

            Console.WriteLine("\n");
            Console.WriteLine("Match Ended");
            Console.WriteLine($"Team 1: {entireCounter1}");
            Console.WriteLine($"Team 2: {entireCounter2}\n");
            Console.WriteLine($"Mvp of the match: {mvpPlayerName}");
            Console.WriteLine($"Points: {mvpPoints}");

            // Setting MVP player 
            match.Mvp = mvpPlayerName;
            match.MvpScore = mvpPoints;
            match.IsDone = true;
            match.SecondsLeft = 0;
            match.MinutesLeft = 0;
            _context.BackgroundTasks.Remove(currentTask);

            // Giving experience for all players
            foreach (var player in userPlayers) // user1 players
            {
                if (entireCounter1 > entireCounter2)
                {
                    if (player.UsersPlayerState.IsCaptain) player.Experience += 225;
                    else player.Experience += 200; // for win
                    if (player.Experience >= player.RequiredExperience)
                    {
                        player.Level += 1;
                        player.Experience -= player.RequiredExperience;
                        player.RequiredExperience += 100;
                    }
                }
                else if (entireCounter1 < entireCounter2) 
                {
                    if (player.UsersPlayerState.IsCaptain) player.Experience += 125;
                    else player.Experience += 100; // for lose
                    if (player.Experience >= player.RequiredExperience)
                    {
                        player.Level += 1;
                        player.Experience -= player.RequiredExperience;
                        player.RequiredExperience += 100;
                    }
                }
                else
                {
                    if (player.UsersPlayerState.IsCaptain) player.Experience += 175;
                    else player.Experience += 150; // for draw
                    if (player.Experience >= player.RequiredExperience)
                    {
                        player.Level += 1;
                        player.Experience -= player.RequiredExperience;
                        player.RequiredExperience += 100;
                    }
                }
                player.Condition -= 10;
            }

            foreach (var player2 in opponentPlayers) // user2 players
            {
                if (entireCounter1 < entireCounter2)
                {
                    if (player2.UsersPlayerState.IsCaptain) player2.Experience += 225;
                    else player2.Experience += 200; // for win
                    if (player2.Experience >= player2.RequiredExperience)
                    {
                        player2.Level += 1;
                        player2.Experience -= player2.RequiredExperience;
                        player2.RequiredExperience += 100;
                    }
                }
                else if (entireCounter1 > entireCounter2)
                {
                    if (player2.UsersPlayerState.IsCaptain) player2.Experience += 125;
                    else player2.Experience += 100; // for win
                    if (player2.Experience >= player2.RequiredExperience)
                    {
                        player2.Level += 1;
                        player2.Experience -= player2.RequiredExperience;
                        player2.RequiredExperience += 100;
                    }
                }
                else
                {
                    if (player2.UsersPlayerState.IsCaptain) player2.Experience += 175;
                    else player2.Experience += 150; // for win
                    if (player2.Experience >= player2.RequiredExperience)
                    {
                        player2.Level += 1;
                        player2.Experience -= player2.RequiredExperience;
                        player2.RequiredExperience += 100;
                    }
                }
                player2.Condition -= 10;
            }

            // Setting userdetails (won/lost/drawn matches) and money for won/lost/drawn match and sponsor if player has any
            var user1RankMultiplier = 1.0;
            var user2RankMultiplier = 1.0;
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
            switch (GetRank(user1.UserDetail.RankPoints))
            {
                case "Bronze":
                    user1RankMultiplier = 1.1;
                    break;
                case "Silver":
                    user1RankMultiplier = 1.2;
                    break;
                case "Gold":
                    user1RankMultiplier = 1.3;
                    break;
                case "Platinum":
                    user1RankMultiplier = 1.4;
                    break;
                case "Diamond":
                    user1RankMultiplier = 1.5;
                    break;
                case "Champion":
                    user1RankMultiplier = 1.7;
                    break;
                case "Grand Champion":
                    user1RankMultiplier = 2;
                    break;
            }
            switch (GetRank(user2.UserDetail.RankPoints))
            {
                case "Bronze":
                    user2RankMultiplier = 1.1;
                    break;
                case "Silver":
                    user2RankMultiplier = 1.2;
                    break;
                case "Gold":
                    user2RankMultiplier = 1.3;
                    break;
                case "Platinum":
                    user2RankMultiplier = 1.4;
                    break;
                case "Diamond":
                    user2RankMultiplier = 1.5;
                    break;
                case "Champion":
                    user2RankMultiplier = 1.7;
                    break;
                case "Grand Champion":
                    user2RankMultiplier = 2;
                    break;
            }
            if (entireCounter1 > entireCounter2)
            {
                user1.UserDetail.MatchesWon += 1;
                user1.UserDetail.AllMatchesWon += 1;
                user1.UserDetail.MatchesPlayed += 1;
                user1.UserDetail.AllMatchesPlayed += 1;
                user1.UserDetail.RankPoints += 35;
                user1.Money += 500;
                if (user1.UserSponsor.SponsorId.HasValue)
                {
                    user1.Money += user1.UserSponsor.Sponsor.WinPrize
                        + (user1.UserSponsor.Sponsor.TitlePrize * user1RankMultiplier);
                    user1.UserSponsor.WinPrizeCount += 1;
                    user1.UserSponsor.WinPrizeTotality += user1.UserSponsor.Sponsor.WinPrize;
                    user1.UserSponsor.TitlePrizeCount += 1;
                    user1.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                }

                user2.UserDetail.MatchesLost += 1;
                user2.UserDetail.AllMatchesLost += 1;
                user2.UserDetail.MatchesPlayed += 1;
                user2.UserDetail.AllMatchesPlayed += 1;
                user2.UserDetail.RankPoints -= 25;
                user2.Money += 200;
                if (user2.UserSponsor.SponsorId.HasValue)
                {
                    user2.Money += user2.UserSponsor.Sponsor.MatchPrize
                        + (user2.UserSponsor.Sponsor.TitlePrize * user2RankMultiplier);
                    user2.UserSponsor.MatchPrizeCount += 1;
                    user2.UserSponsor.MatchPrizeTotality += user2.UserSponsor.Sponsor.MatchPrize;
                    user2.UserSponsor.TitlePrizeCount += 1;
                    user2.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                }
            }
            else if (entireCounter1 < entireCounter2)
            {
                user2.UserDetail.MatchesWon += 1;
                user2.UserDetail.AllMatchesWon += 1;
                user2.UserDetail.MatchesPlayed += 1;
                user2.UserDetail.AllMatchesPlayed += 1;
                user2.UserDetail.RankPoints += 35;
                user2.Money += 500;
                if (user2.UserSponsor.SponsorId.HasValue)
                {
                    user2.Money += user2.UserSponsor.Sponsor.WinPrize
                        + (user2.UserSponsor.Sponsor.TitlePrize * user2RankMultiplier);
                    user2.UserSponsor.WinPrizeCount += 1;
                    user2.UserSponsor.WinPrizeTotality += user2.UserSponsor.Sponsor.MatchPrize;
                    user2.UserSponsor.TitlePrizeCount += 1;
                    user2.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                }
                user1.UserDetail.MatchesLost += 1;
                user1.UserDetail.AllMatchesLost += 1;
                user1.UserDetail.MatchesPlayed += 1;
                user1.UserDetail.AllMatchesPlayed += 1;
                user1.UserDetail.RankPoints -= 25;
                user1.Money += 200;
                if (user1.UserSponsor.SponsorId.HasValue)
                {
                    user1.Money += user1.UserSponsor.Sponsor.MatchPrize
                        + (user1.UserSponsor.Sponsor.TitlePrize * user1RankMultiplier);
                    user1.UserSponsor.MatchPrizeCount += 1;
                    user1.UserSponsor.MatchPrizeTotality += user2.UserSponsor.Sponsor.MatchPrize;
                    user1.UserSponsor.TitlePrizeCount += 1;
                    user1.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                }
                else
                {
                    user2.UserDetail.MatchesDrawn += 1;
                    user2.UserDetail.AllMatchesDrawn += 1;
                    user2.UserDetail.MatchesPlayed += 1;
                    user2.UserDetail.AllMatchesPlayed += 1;
                    user2.UserDetail.RankPoints += 15;
                    user2.Money += 300;
                    if (user1.UserSponsor.SponsorId.HasValue)
                    {
                        user1.Money += user1.UserSponsor.Sponsor.MatchPrize
                            + (user1.UserSponsor.Sponsor.TitlePrize * user1RankMultiplier);
                        user1.UserSponsor.MatchPrizeCount += 1;
                        user1.UserSponsor.MatchPrizeTotality += user2.UserSponsor.Sponsor.MatchPrize;
                        user1.UserSponsor.TitlePrizeCount += 1;
                        user1.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                    }

                    user1.UserDetail.MatchesDrawn += 1;
                    user1.UserDetail.AllMatchesDrawn += 1;
                    user1.UserDetail.MatchesPlayed += 1;
                    user1.UserDetail.AllMatchesPlayed += 1;
                    user1.UserDetail.RankPoints += 15;
                    user1.Money += 300;
                    if (user2.UserSponsor.SponsorId.HasValue)
                    {
                        user2.Money += user2.UserSponsor.Sponsor.MatchPrize
                            + (user2.UserSponsor.Sponsor.TitlePrize * user2RankMultiplier);
                        user2.UserSponsor.MatchPrizeCount += 1;
                        user2.UserSponsor.MatchPrizeTotality += user2.UserSponsor.Sponsor.MatchPrize;
                        user2.UserSponsor.TitlePrizeCount += 1;
                        user2.UserSponsor.TitlePrizeTotality += user1.UserSponsor.Sponsor.TitlePrize;
                    }
                }
            }
            // Setting statements
            user1.IsAccepted = false;
            user1.IsInQueue = false;
            user1.IsPlaying = false;

            user2.IsAccepted = false;
            user2.IsInQueue = false;
            user2.IsPlaying = false;

            // Giving money for stadium
            user1.Money += user1.Stadium.IncomePerViewer * user1.Stadium.SeatsCapacity;

            await _context.SaveChangesAsync();

            return;
        }
    }
}
