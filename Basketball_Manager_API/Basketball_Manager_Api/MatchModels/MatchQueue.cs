using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.ViewModel;
using Basketball_Manager_Db.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Hangfire;

namespace Basketball_Manager_Api.MatchModels
{
    public class MatchQueue
    {
        private readonly ApplicationDbContext _context;

        public MatchQueue(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LookingForPlayer(CancellationToken token, string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                var userAsList = new List<UserModel> { user };
                var userRank = user.UserDetail.RankPoints;
                var usersInQueue = _context.Users.Where(x => x.IsInQueue == true).ToList();
                var rankPointsDifference = 100;

                while (true)
                {
                    for (int i = rankPointsDifference - 100; i <= rankPointsDifference; i++)
                    {
                        var opponentList = usersInQueue.Where(x =>
                            x.UserDetail.RankPoints == userRank - i || x.UserDetail.RankPoints == userRank + i).Except(userAsList);

                        var opponent = opponentList.FirstOrDefault();

                        if (opponent != null)
                        {
                            Console.WriteLine("Opponent found");
                            Console.WriteLine($"Name: {opponent.Name}");
                            Console.WriteLine($"Rank: {opponent.UserDetail.RankPoints}"); ;

                            var bgTask = _context.BackgroundTasks.Where(x => x.UserId == user.Id).OrderBy(x => x.Id).LastOrDefault(x => x.TaskName == "queue");
                            var opponentBgTask = _context.BackgroundTasks.Where(x => x.UserId == opponent.Id).OrderBy(x => x.Id).LastOrDefault(x => x.TaskName == "queue");
                            BackgroundJob.Delete(opponentBgTask.JobId);

                            user.IsAccepted = true;
                            user.IsInQueue = false;
                            user.IsPlaying = false;
                            opponent.IsAccepted = true;
                            opponent.IsInQueue = false;
                            opponent.IsPlaying = false;

                            _context.BackgroundTasks.Remove(bgTask);
                            _context.BackgroundTasks.Remove(opponentBgTask);

                            await _context.SaveChangesAsync();

                            var newMatch = new UsersMatchHistoryModel
                            {
                                MatchDate = DateTime.Now,
                                User2Club = opponent.ClubName,
                                User2Score = 0,
                                UserClub = user.ClubName,
                                UserScore = 0,
                                UserId = user.Id,
                                User2Id = opponent.Id,
                                Mvp = "",
                                MvpScore = 0,
                                MinutesLeft = 15,
                                SecondsLeft = 0,
                            };

                            _context.UsersMatchesHistory.Add(newMatch);
                            await _context.SaveChangesAsync();
                            await Task.Delay(TimeSpan.FromSeconds(3), token);
                            var postModel = new
                            {
                                UserId = userId,
                                OpponentId = opponent.Id,
                            };
                            var postResponse = new UsersMatchHistoryViewModel();
                            
                            using (var httpClient = new HttpClient())
                            {
                                StringContent content = new StringContent(JsonConvert.SerializeObject(postModel), Encoding.UTF8, "application/json");

                                using (var response = await httpClient.PutAsync("https://localhost:44326/api/Match/match", content))
                                {
                                    string apiResponse = await response.Content.ReadAsStringAsync();
                                    postResponse = JsonConvert.DeserializeObject<UsersMatchHistoryViewModel>(apiResponse);
                                }
                            }
                            BackgroundJob.Delete(bgTask.JobId);
                            Console.WriteLine(postResponse.ToString());

                            return;
                        }
                        else if (rankPointsDifference == 500)
                        {
                            rankPointsDifference = 100;
                        }
                    }
                    rankPointsDifference += 100;
                    await Task.Delay(TimeSpan.FromSeconds(3), token);
                }
            }
            else return;
        }
    }
}
