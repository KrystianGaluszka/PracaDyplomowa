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
        public async Task<string> PutUserItem(ItemPutModel itemPutModel)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == itemPutModel.ItemId);

            if (item != null)
            {
                var user = _context.Users.FirstOrDefault(x=> x.Id == itemPutModel.UserId);
                var userItem = user.UsersItems.FirstOrDefault(x=> x.ItemId == itemPutModel.ItemId);

                if (userItem != null)
                {
                    var cost = itemPutModel.Count * item.Price;

                    var expense = new ExpensesModel
                    {
                        UserId = user.Id,
                        ItemName = item.Name,
                        TransactionDate = DateTime.Now,
                        Count = itemPutModel.Count,
                        Value = cost.ToString(),
                        IconPath = item.IconPath,
                    };

                    userItem.Count += itemPutModel.Count;
                    user.Money -= cost;
                    _context.Expenses.Add(expense);

                    await _context.SaveChangesAsync();

                    return "success";
                }
                else return "error"; 
            }
            else return "error";
        }

        public async Task<string> ExtendContract(ExtendContract extendContract)
        {
            var count = extendContract.Count;
            var player = _context.UsersPlayers.FirstOrDefault(x=> x.Id == extendContract.UserPlayerId);
            var item = _context.UsersItems.FirstOrDefault(x=> x.Id == extendContract.UserItemId);

            if (player != null && item != null)
            {
                item.Count -= count;
                player.Contract += count;

                await _context.SaveChangesAsync();

                return "success";
            }

            return "error";
        }

        public async Task<string> UseItem(UseItemPutModel useItemPutModel)
        {
            var item = _context.UsersItems.FirstOrDefault(x => x.Id == useItemPutModel.UserItemId);
            var player = _context.UsersPlayers.FirstOrDefault(x => x.Id == useItemPutModel.UserPlayerId);

            if (item != null && player != null)
            {
                item.Count -= 1;
                if (item.Item.Name == "Med-Kit") player.UsersPlayerState.IsInjured = false;
                else if (item.Item.Name == "XP-Boost") player.UsersPlayerState.IsBoosted = true;

                await _context.SaveChangesAsync();

                return "success";
            }

            return "error";
        }

        public async Task<IEnumerable<UsersPlayerViewModel>> OpenChest(OpenChestPutModel openChestPutModel)
        {
            var userItem = _context.UsersItems.FirstOrDefault(x => x.Id == openChestPutModel.UserItemId);
            var playersDropped = new List<UsersPlayerModel>();
            var itemName = userItem.Item.Name;

            var commonPlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Common);
            var uncommonPlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Uncommon);
            var rarePlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Rare);
            var epicPlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Epic);
            var masterworkPlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Masterwork);
            var legendaryPlayers = _context.Players.Where(x => x.Rarity == PlayerRarity.Legendary);

            for (int i = 0; i < 3; i++)
            {
                var id = Guid.NewGuid().ToString();
                var rnd = new Random();
                var player = commonPlayers.Skip(rnd.Next(commonPlayers.Count() - 1)).Take(1).First();
                switch (itemName)
                {
                    case "Uncommon chest":
                        if (i == 0) player = uncommonPlayers.Skip(rnd.Next(uncommonPlayers.Count() - 1)).Take(1).First();
                        break;
                    case "Rare chest":
                        player = uncommonPlayers.Skip(rnd.Next(uncommonPlayers.Count() - 1)).Take(1).First();
                        if (50 > rnd.Next(1, 101)) player = rarePlayers.Skip(rnd.Next(rarePlayers.Count() - 1)).Take(1).First();
                        break;
                    case "Epic chest":
                        player = uncommonPlayers.Skip(rnd.Next(uncommonPlayers.Count() - 1)).Take(1).First();
                        if (50 > rnd.Next(1, 101)) player = epicPlayers.Skip(rnd.Next(epicPlayers.Count() - 1)).Take(1).First();
                        break;
                    case "Masterwork chest":
                        player = rarePlayers.Skip(rnd.Next(rarePlayers.Count() - 1)).Take(1).First();
                        if (50 > rnd.Next(1, 101)) player = masterworkPlayers.Skip(rnd.Next(masterworkPlayers.Count() - 1)).Take(1).First();
                        break;
                    case "Legendary chest":
                        player = epicPlayers.Skip(rnd.Next(epicPlayers.Count() - 1)).Take(1).First();
                        if (i == 0) player = legendaryPlayers.Skip(rnd.Next(legendaryPlayers.Count() - 1)).Take(1).First();
                        break;
                }
                

                var droppedPlayer = new UsersPlayerModel
                {
                    Level = player.Level,
                    Condition = 100,
                    Contract = 25,
                    Experience = 0,
                    Player = player,
                    RequiredExperience = player.Level * 100,
                    Salary = player.Level * 10,
                    Score = 0,
                    TrainingType = Training.None,
                    UserId = openChestPutModel.UserId,
                    UsersPlayerPoints = getPoints(),
                    UsersPlayerState = getState()
                };

                playersDropped.Add(droppedPlayer);
                _context.UsersPlayers.Add(droppedPlayer);

                await _context.SaveChangesAsync();
            }
            userItem.Count--;

            await _context.SaveChangesAsync();

            var config = MapperConfig();
            var mapper = new Mapper(config);

            var playersDroppedModel = mapper.Map<List<UsersPlayerModel>, List<UsersPlayerViewModel>>(playersDropped);

            return playersDroppedModel;
        }

        public UsersPlayerPointsModel getPoints()
        {
            var playerPoints = new UsersPlayerPointsModel
            {
                AllOnePoints = 0,
                AllTwoPoints = 0,
                AllThreePoints = 0,
                OnePoints = 0,
                TwoPoints = 0,
                ThreePoints = 0
            };
            return playerPoints;
        }

        public UsersPlayerStateModel getState()
        {
            var playerState = new UsersPlayerStateModel()
            {
                IsBoosted = false,
                IsCaptain = false,
                IsInjured = false,
                IsOnAuction = false,
                IsOnBench = false,
                IsPlaying = false
            };

            return playerState;
        }
    }
}