using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("usersplayers")]
        public async Task<ActionResult> GetAllUsersPlayers()
        {
            return Ok(await _playerRepository.GetAllUsersPlayers());
        }

        [HttpPut("editSquad")]
        public async Task<ActionResult> EditSquad(EditTeamPutModel editTeamPutModel)
        {
            return Ok(await _playerRepository.EditTeam(editTeamPutModel));
        }

        [HttpPut("updatetraining")]
        public async Task<ActionResult> UpdateTraining(UpdateTrainingPutModel updateTraining)
        {
            return Ok(await _playerRepository.UpdateTraining(updateTraining));
        }
    }
}
