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
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemModel> GetItem(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
