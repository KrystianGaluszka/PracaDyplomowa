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
    public class AuctionDetailsRepository : IAuctionDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuctionDetailsModel>> GetAllAuctionDetails()
        {
            return await _context.AuctionDetails.ToListAsync();
        }

        public async Task<AuctionDetailsModel> GetAuctionDetails(int id)
        {
            return await _context.AuctionDetails.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
