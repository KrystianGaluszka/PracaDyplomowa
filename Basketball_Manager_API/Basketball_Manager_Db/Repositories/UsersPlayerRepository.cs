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
    public class UsersPlayerRepository : IUsersPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersPlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersPlayerModel>> GetAllUsersPlayers()
        {
            return await _context.UsersPlayers.ToListAsync();
        }

        public async Task<UsersPlayerModel> GetUsersPlayer(int id)
        {
            return await _context.UsersPlayers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
