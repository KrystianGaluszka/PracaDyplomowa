using Basketball_Manager_Api.HangfireBackgroundService;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.DeleteModels;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly ApplicationDbContext _context;

        public AuctionController(IAuctionRepository auctionRepository, ApplicationDbContext context)
        {
            _auctionRepository = auctionRepository;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Post(AuctionPostModel auctionPostModel)
        {

            var auctionId = await _auctionRepository.PostAuction(auctionPostModel);
            var jobId = BackgroundJob.Enqueue<AuctionRemainingTime>(x => x.CountDown(CancellationToken.None, auctionId));
            _context.BackgroundTasks.Add(new BackgroundTaskModel
            {
                IsStarted = true,
                JobId = jobId,
                TaskName = $"{auctionPostModel.UserPlayerId}-{auctionPostModel.UserId}-auction",
                UserId = auctionPostModel.UserId,
            });

            return Ok("success");
        }

        [HttpPut("bid")]
        public async Task<ActionResult> BidPlayer(BidFromAuctionPutModel bidFromAuction)
        {
            return Ok(await _auctionRepository.BidPlayer(bidFromAuction));
        }

        [HttpPut("buy")]
        public async Task<ActionResult> BuyPlayer(BuyFromAuctionPutModel buyFromAuction)
        {
            return Ok(await _auctionRepository.BuyPlayer(buyFromAuction));
        }

        [HttpDelete("deleteafterbuy/{auctionId}")]
        public async Task<ActionResult> DeleteAfterPurchase(int auctionId)
        {
            return Ok(await _auctionRepository.DeleteAfterPurchase(auctionId));
        }

        [HttpPut("quicksell")]
        public async Task<ActionResult> QuickSell(QuickSellDeleteModel quickSellDeleteModel)
        {
            return Ok(await _auctionRepository.QuickSell(quickSellDeleteModel));
        }

        [HttpPut("remove")]
        public async Task<ActionResult> RemovePlayer(RemoveFromAuctionDeleteModel removeFromAuction)
        {
            return Ok(await _auctionRepository.RemovePlayer(removeFromAuction));
        }
    }
}
