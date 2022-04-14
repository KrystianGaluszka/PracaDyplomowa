using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
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

        public async Task<IEnumerable<UsersPlayerViewModel>> GetAllUsersPlayers()
        {
            var usersPlayers = await _context.UsersPlayers.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var usersPlayersModel = mapper.Map<List<UsersPlayerModel>, List<UsersPlayerViewModel>>(usersPlayers);

            return usersPlayersModel;
        }

        public async Task<PlayerViewModel> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var playerModel = mapper.Map<PlayerModel, PlayerViewModel>(player);

            return playerModel;
        }

        public async Task<string> EditTeam(EditTeamPutModel editTeamPutModel)
        {
            var squadPlayerIds = editTeamPutModel.SquadIds;
            var benchPlayerIds = editTeamPutModel.BenchIds;
            var restPlayerIds = editTeamPutModel.RestPlayersIds;
            var captainId = 0;
            int.TryParse(editTeamPutModel.CaptainId, out captainId);

            foreach (var playerId in squadPlayerIds)
            {
                var player = await _context.UsersPlayers.FirstOrDefaultAsync(x => x.Id == playerId);
                if (player != null)
                {
                    player.UsersPlayerState.IsPlaying = true;
                    player.UsersPlayerState.IsOnBench = false;
                    await _context.SaveChangesAsync();
                }
            }
            foreach (var playerId in benchPlayerIds)
            {
                var player = await _context.UsersPlayers.FirstOrDefaultAsync(x => x.Id == playerId);
                if (player != null)
                {
                    player.UsersPlayerState.IsPlaying = false;
                    player.UsersPlayerState.IsOnBench = true;
                    await _context.SaveChangesAsync();
                }
            }
            foreach (var playerId in restPlayerIds)
            {
                var player = await _context.UsersPlayers.FirstOrDefaultAsync(x => x.Id == playerId);
                if (player != null)
                {
                    player.UsersPlayerState.IsPlaying = false;
                    player.UsersPlayerState.IsOnBench = false;
                    await _context.SaveChangesAsync();
                }
            }

            var newCaptain = await _context.UsersPlayers.FirstOrDefaultAsync(x => x.Id == captainId);
            if (newCaptain != null)
            {
                var oldCaptain = _context.UsersPlayers.FirstOrDefault(x => x.UsersPlayerState.IsCaptain == true);
                if (oldCaptain != null)
                {
                    oldCaptain.UsersPlayerState.IsCaptain = false;
                }
                newCaptain.UsersPlayerState.IsCaptain = true;
                _context.SaveChanges();
            }

            return "success";
        }

        public async Task<string> UpdateTraining(UpdateTrainingPutModel updateTraining)
        {
            var userPlayers = _context.UsersPlayers.Where(x => x.UserId == updateTraining.UserId);

            foreach (var option in updateTraining.UserPlayersOption)
            {
                var player = userPlayers.FirstOrDefault(x => x.Id == option.UserPlayerId);

                switch (option.TrainingType)
                {
                    case "None":
                        player.TrainingType = Training.None;
                        break;
                    case "Light":
                        player.TrainingType = Training.Light;
                        break;
                    case "Medium":
                        player.TrainingType = Training.Medium;
                        break;
                    case "Hard":
                        player.TrainingType = Training.Hard;
                        break;
                    case "Rest":
                        player.TrainingType = Training.Rest;
                        break;
                }
            }
            await _context.SaveChangesAsync();

            return "success";
        }
    }
}
