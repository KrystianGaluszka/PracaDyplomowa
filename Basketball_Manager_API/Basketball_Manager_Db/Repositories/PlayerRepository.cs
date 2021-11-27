using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerModel>> GetAllPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<PlayerModel> GetPlayer(int id)
        {
            return await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
