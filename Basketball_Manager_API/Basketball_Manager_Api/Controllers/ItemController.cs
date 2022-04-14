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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _itemRepository.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _itemRepository.GetItem(id));
        }

        [HttpPut("additem")]
        public async Task<ActionResult> PostUserItem(ItemPutModel itemPutModel)
        {
            return Ok(await _itemRepository.PutUserItem(itemPutModel));
        }

        [HttpPut("extendcontract")]
        public async Task<ActionResult> ExtendContract(ExtendContract extendContract)
        {
            return Ok(await _itemRepository.ExtendContract(extendContract));
        }

        [HttpPut("useitem")]
        public async Task<ActionResult> UseItem(UseItemPutModel useItemPutModel)
        {
            return Ok(await _itemRepository.UseItem(useItemPutModel));
        }

        [HttpPut("openchest")]
        public async Task<ActionResult> OpenChest(OpenChestPutModel openChestPutModel)
        {
            return Ok(await _itemRepository.OpenChest(openChestPutModel));
        }
    }
}
