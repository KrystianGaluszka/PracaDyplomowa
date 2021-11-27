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
    public class UsersMatchHistoryRepository : IUsersMatchHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersMatchHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersMatchHistoryModel>> GetAllUsersMatchHistory()
        {
            return await _context.UsersMatchHistory.ToListAsync();
        }

        public async Task<UsersMatchHistoryModel> GetUsersMatchHistory(int id)
        {
            return await _context.UsersMatchHistory.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
