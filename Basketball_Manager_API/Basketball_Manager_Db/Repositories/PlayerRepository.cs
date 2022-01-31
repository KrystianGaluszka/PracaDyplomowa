using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerViewModel>> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var playersModel = mapper.Map<List<PlayerModel>, List<PlayerViewModel>>(players);

            return playersModel;
        }

        public async Task<PlayerViewModel> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var playerModel = mapper.Map<PlayerModel, PlayerViewModel>(player);

            return playerModel;
        }

        public async Task<UsersPlayerModel> PostAddPlayer(int id, string userId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

            var userPlayerModel = new UsersPlayerModel
            {
                Condition = 100,
                Contract = 35,
                IsCaptain = false,
                IsOnAuction = false,
                Level = player.Level,
                Salary = player.Salary,
                UserId = userId,
                PlayerId = player.Id,
            };

            var result = _context.UsersPlayers.Add(userPlayerModel);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
