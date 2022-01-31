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
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumRepository _stadiumRepository;

        public StadiumController(IStadiumRepository stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        // GET: api/<SportsHallController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _stadiumRepository.GetAllStadiums());
        }

        // GET api/<SportsHallController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _stadiumRepository.GetStadium(id));
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
