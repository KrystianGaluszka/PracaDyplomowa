using Basketball_Manager_Api.HangfireBackgroundService;
using Basketball_Manager_Api.MatchModels;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.GetModel;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMatchRepository _matchRepository;

        public MatchController(ApplicationDbContext context, IServiceScopeFactory serviceScopeFactory, IMatchRepository matchRepository)
        {
            _context = context;
            _matchRepository = matchRepository;
        }

        [HttpGet("actualmatch/{userId}")]
        public async Task<ActionResult> GetActualMatch(string userId)
        {
            return Ok(await _matchRepository.GetActualMatch(userId));
        }

        [HttpPut("match")]
        public async Task<string> StartMatch(MatchPutModel matchPutModel)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == matchPutModel.UserId);
            var opponent = _context.Users.FirstOrDefault(x => x.Id == matchPutModel.OpponentId);
            user.IsInQueue = false;
            user.IsAccepted = false;
            user.IsPlaying = true;
            opponent.IsInQueue = false;
            opponent.IsAccepted = false;
            opponent.IsPlaying = true;

            var jobId = BackgroundJob.Enqueue<MatchGame>(x => 
                x.Match(CancellationToken.None, matchPutModel.UserId, matchPutModel.OpponentId)
            );

            _context.BackgroundTasks.Add(new BackgroundTaskModel()
            {
                IsStarted = false,
                JobId = jobId,
                TaskName = "match",
                UserId = user.Id,
                User2Id = opponent.Id
            });

            await _context.SaveChangesAsync();
            return "match started";
        }

        [HttpPut("queue")]
        public async Task<ActionResult> Queue(LookingForMatchPutModel lookingForMatch)
        {
            var jobId = BackgroundJob.Enqueue<MatchQueue>(x => x.LookingForPlayer(CancellationToken.None, lookingForMatch.UserId));
            var user = _context.Users.FirstOrDefault(x => x.Id == lookingForMatch.UserId);


            user.IsInQueue = true;
            _context.BackgroundTasks.Add(new BackgroundTaskModel()
            {
                JobId = jobId,
                UserId = user.Id,
                TaskName = "queue",
                IsStarted = true,
            });

            await _context.SaveChangesAsync();
            return Ok("started queue");
        }

        [HttpPut("cancelqueue")]
        public async Task<ActionResult> CancelQueue(LookingForMatchPutModel lookingForMatch)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == lookingForMatch.UserId);

            user.IsInQueue = false;
            var jobToDelete = _context.BackgroundTasks.Where(x => x.UserId == user.Id).FirstOrDefault(x => x.TaskName == "queue");

            BackgroundJob.Delete(jobToDelete.JobId);

            _context.BackgroundTasks.Remove(jobToDelete);

            await _context.SaveChangesAsync();

            return Ok("canceled queue");
        }

        [HttpGet("matchtask/{userId}")]
        public async Task<BackgroundTaskViewModel> GetTask(string userId)
        {

            return await _matchRepository.GetTask(userId);
        }

        [HttpGet("gettime/{userId}")]
        public async Task<GetTimeModel> GetTime(string userId)
        {
            return await _matchRepository.GetTime(userId);
        }
    }
}
