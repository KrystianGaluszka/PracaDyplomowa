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
    [Route("api/")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorController(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        [HttpGet("sponsor")]
        public async Task<ActionResult> GetAllSponsors()
        {
            return Ok(await _sponsorRepository.GetAllSponsors());
        }

        [HttpGet("sponsor/{id}")]
        public async Task<ActionResult> GetSponsor(int id)
        {
            return Ok(await _sponsorRepository.GetSponsor(id));
        }
        [HttpGet("usersponsor")]
        public async Task<ActionResult> GetAllUserSponsors()
        {
            return Ok(await _sponsorRepository.GetAllUserSponsors());
        }

        [HttpGet("usersponsor/{id}")]
        public async Task<ActionResult> GetUserSponsor(int id)
        {
            return Ok(await _sponsorRepository.GetUserSponsor(id));
        }

        [HttpPut("sponsor/changesponsor")]
        public async Task<ActionResult> ChangeSponsor(ChangeSponsorPutModel changeSponsorPutModel)
        {
            return Ok(await _sponsorRepository.ChangeSponsor(changeSponsorPutModel));
        }
    }
}
