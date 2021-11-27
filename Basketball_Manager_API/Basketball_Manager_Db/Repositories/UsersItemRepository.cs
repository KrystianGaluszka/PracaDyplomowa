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
    public class UsersItemRepository : IUsersItemRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersItemModel>> GetAllUsersItems()
        {
            return await _context.UsersItems.ToListAsync();
        }

        public async Task<UsersItemModel> GetUsersItem(int id)
        {
            return await _context.UsersItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
