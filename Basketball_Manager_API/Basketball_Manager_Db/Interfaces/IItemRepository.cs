using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface IItemRepository
    {
        Task<string> PutUserItem(ItemPutModel itemPutModel);
        Task<string> ExtendContract(ExtendContract extendContract);
        Task<string> UseItem(UseItemPutModel useItemPutModel);
        Task<IEnumerable<UsersPlayerViewModel>> OpenChest(OpenChestPutModel openChestPutModel);
    }
}
