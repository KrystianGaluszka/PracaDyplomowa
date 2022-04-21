using System.Threading.Tasks;

namespace Basketball_Manager_Api.HangfireBackgroundInterfaces
{
    public interface IRecurringJobs
    {
        public Task TrainingRewards();
        public Task SubtractContracts();
    }
}
