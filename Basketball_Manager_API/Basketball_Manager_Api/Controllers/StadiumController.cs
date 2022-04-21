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
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumRepository _stadiumRepository;

        public StadiumController(IStadiumRepository stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        [HttpPut("upgrade")]
        public async Task<IActionResult> UpgrafeStadium(UpgradeStadiumPutModel upgradeStadiumPutModel)
        {
            return Ok(await _stadiumRepository.UpgradeStadium(upgradeStadiumPutModel));
        }

        [HttpPut("namechange")]
        public async Task<IActionResult> StadiumNameChange(StadiumPutModel stadiumPutModel)
        {
            return Ok(await _stadiumRepository.ChangeStadiumName(stadiumPutModel));
        }


    }
}
