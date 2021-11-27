using Basketball_Manager_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemModel>> GetAllItems();
        Task<ItemModel> GetItem(int id);
    }
}
