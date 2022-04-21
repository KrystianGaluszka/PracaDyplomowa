using Basketball_Manager_Api.HangfireBackgroundInterfaces;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Api.HangfireBackgroundService
{
    public class RecurringJobs : IRecurringJobs
    {
        private readonly ApplicationDbContext _context;

        public RecurringJobs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task TrainingRewards()
        {
            var userPlayers = _context.UsersPlayers.Where(x => x.TrainingType != Training.None);
            System.Console.WriteLine("Training Rewards!!!");
            foreach (var player in userPlayers)
            {
                switch (player.TrainingType)
                {
                    case Training.Rest:
                        if (player.Condition + 10 >= 100) player.Condition = 100;
                        else player.Condition += 10;
                        break;
                    case Training.Light:
                        if (player.Condition < 2)
                        {
                            break;
                        }
                        player.Experience += 10;
                        player.Condition -= 1;
                        if (player.Experience >= player.RequiredExperience)
                        {
                            player.Level += 1;
                            player.Experience -= player.RequiredExperience;
                            player.RequiredExperience += 100;
                        }
                        break;
                    case Training.Medium:
                        if (player.Condition < 5)
                        {
                            break;
                        }
                        player.Experience += 20;
                        player.Condition -= 2; 
                        if (player.Experience >= player.RequiredExperience)
                            {
                            player.Level += 1;
                            player.Experience -= player.RequiredExperience;
                            player.RequiredExperience += 100;
                            }
                        break;
                    case Training.Hard:
                        if (player.Condition < 10)
                        {
                            break;
                        }
                        player.Experience += 50;
                        player.Condition -= 4;
                        if (player.Experience >= player.RequiredExperience)
                            {
                            player.Level += 1;
                            player.Experience -= player.RequiredExperience;
                            player.RequiredExperience += 100;
                            }
                        break;
                }
            }
            await _context.SaveChangesAsync();
            return;
        }
        public async Task SubtractContracts()
        {
            var usersPlayers = _context.UsersPlayers;

            foreach (var user in usersPlayers)
            {
                user.Contract -= 1;
            }
            await _context.SaveChangesAsync();
            return;
        }
    }
}
