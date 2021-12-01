using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IEnumerable<ItemModel>> GetAll()
        {
            return await _itemRepository.GetAllItems();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<ItemModel> Get(int id)
        {
            return await _itemRepository.GetItem(id);
        }

        // POST api/<ItemController>
        [HttpPut]
        public async Task<UsersItemModel> PostUserItem(int count, ItemPutModel itemPutModel)
        {
            return await _itemRepository.PutUserItem(count, itemPutModel);
        }

        //// PUT api/<ItemController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ItemController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
