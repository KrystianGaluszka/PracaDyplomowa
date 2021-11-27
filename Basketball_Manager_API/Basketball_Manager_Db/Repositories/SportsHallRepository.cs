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
    public class SportsHallRepository : ISportsHallRepository
    {
        private readonly ApplicationDbContext _context;
        public SportsHallRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SportsHallModel>> GetAllSportsHalls()
        {
            return await _context.SportsHalls.ToListAsync();
        }

        public async Task<SportsHallModel> GetSportsHall(int id)
        {
            return await _context.SportsHalls.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
