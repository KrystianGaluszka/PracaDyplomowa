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
    public class SponsorRepository : ISponsorRepository
    {
        private readonly ApplicationDbContext _context;
        public SponsorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SponsorModel>> GetAllSponsors()
        {
            return await _context.Sponsors.ToListAsync();
        }

        public async Task<SponsorModel> GetSponsor(int id)
        {
            return await _context.Sponsors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
