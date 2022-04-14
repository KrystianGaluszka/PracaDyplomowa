using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskService.MatchQueueService
{
    public class MatchQueueHostedService: IHostedService
    {
        private readonly ILogger<MatchQueueHostedService> _logger;
        public IMatchQueue _matchQueue { get; }
        private int counter = 0;

        public MatchQueueHostedService(ILogger<MatchQueueHostedService> logger, IMatchQueue matchQueue)
        {
            _logger = logger;
            _matchQueue = matchQueue;
        }

         async Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Queued Hosted Service is starting.");

            while (!cancellationToken.IsCancellationRequested)
            {
                var workItem = await _matchQueue.DequeueAsync(cancellationToken);

                try
                {
                    await workItem(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                       "Error occurred executing {WorkItem}.", nameof(workItem));
                }
            }

            _logger.LogInformation("Queued Hosted Service is stopping.");
        }

        //public async Task StartAsync(CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        Interlocked.Increment(ref counter);
        //        _logger.LogInformation($"Queue printing number: {counter}");
        //        await Task.Delay(1000 * 5);
        //    }
        //}

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Match Found");
            return Task.CompletedTask;
        }
    }
}
