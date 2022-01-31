using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllItems()
        {
            var items = await _context.Items.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var itemModel = mapper.Map<List<ItemModel>, List<ItemViewModel>>(items);

            return itemModel;
        }

        public async Task<ItemViewModel> GetItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var itemModel = mapper.Map<ItemModel, ItemViewModel>(item);

            return itemModel;
        }
        public async Task<UsersItemModel> PutUserItem(int count, ItemPutModel itemPutModel)
        {
            var item = _context.Items.Where(x => x.Id == itemPutModel.ItemId).FirstOrDefault();
            var userItem = _context.UsersItems.Where(x => x.UserId == itemPutModel.UserId && x.Item == item).FirstOrDefault();
            var id = userItem.Id;

            var addItemToUser = _context.UsersItems.Where(x => x.Id == id).FirstOrDefault();
            addItemToUser.Count = count;
            _context.SaveChanges();

            return await _context.UsersItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}