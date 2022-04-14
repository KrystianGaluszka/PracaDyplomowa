using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskService.MatchQueueService
{
    public interface IMatchQueue
    {
        public void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);
        public Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}
