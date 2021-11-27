using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
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

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IEnumerable<PlayerModel>> GetAll()
        {
            return await _playerRepository.GetAllPlayers();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<PlayerModel> Get(int id)
        {
            return await _playerRepository.GetPlayer(id);
        }

        //// POST api/<PlayerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PlayerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PlayerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
