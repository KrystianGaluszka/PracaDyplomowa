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
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _playerRepository.GetAllPlayers());
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _playerRepository.GetPlayer(id));
        }

        [HttpPost("addPlayer")]
        public async Task<ActionResult> AddPlayer(int id, string userId)
        {
            return Ok(await _playerRepository.PostAddPlayer(id, userId));
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
