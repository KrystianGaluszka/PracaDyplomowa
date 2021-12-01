using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
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
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        // GET: api/<AuctionController>
        [HttpGet]
        public async Task<IEnumerable<AuctionModel>> GetAll()
        {
            return await _auctionRepository.GetAllAuctions();
        }

        // GET api/<AuctionController>/5
        [HttpGet("{id}")]
        public async Task<AuctionModel> Get(int id)
        {
            return await _auctionRepository.GetAuction(id);
        }

        // POST api/<AuctionController>
        [HttpPost]
        public async Task<AuctionModel> Post(AuctionPostModel auctionPostModel)
        {
            return await _auctionRepository.PostAuction(auctionPostModel);
        }

        //// PUT api/<AuctionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuctionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
