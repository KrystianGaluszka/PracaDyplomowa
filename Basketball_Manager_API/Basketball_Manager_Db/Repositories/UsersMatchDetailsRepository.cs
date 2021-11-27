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
    public class UsersMatchDetailsRepository : IUsersMatchDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersMatchDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersMatchDetailsModel>> GetAllUsersMatchDetails()
        {
            return await _context.UsersMatchDetails.ToListAsync();
        }

        public async Task<UsersMatchDetailsModel> GetUsersMatchDetails(int id)
        {
            return await _context.UsersMatchDetails.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
