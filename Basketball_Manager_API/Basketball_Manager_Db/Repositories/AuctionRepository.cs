﻿using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuctionModel>> GetAllAuctions()
        {
            return await _context.Auctions.ToListAsync();
        }

        public async Task<AuctionModel> GetAuction(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
