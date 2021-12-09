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
    public class StadiumRepository : IStadiumRepository
    {
        private readonly ApplicationDbContext _context;
        public StadiumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StadiumModel>> GetAllStadiums()
        {
            return await _context.Stadiums.ToListAsync();
        }

        public async Task<StadiumModel> GetStadium(int id)
        {
            return await _context.Stadiums.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
