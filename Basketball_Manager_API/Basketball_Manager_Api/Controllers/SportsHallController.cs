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
    public class SportsHallController : ControllerBase
    {
        private readonly ISportsHallRepository _sportsHallRepository;

        public SportsHallController(ISportsHallRepository sportsHallRepository)
        {
            _sportsHallRepository = sportsHallRepository;
        }

        // GET: api/<SportsHallController>
        [HttpGet]
        public async Task<IEnumerable<SportsHallModel>> GetAll()
        {
            return await _sportsHallRepository.GetAllSportsHalls();
        }

        // GET api/<SportsHallController>/5
        [HttpGet("{id}")]
        public async Task<SportsHallModel> Get(int id)
        {
            return await _sportsHallRepository.GetSportsHall(id);
        }

        //// POST api/<SportsHallController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SportsHallController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SportsHallController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
