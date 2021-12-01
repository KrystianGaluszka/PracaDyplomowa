using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Models;

namespace Basketball_Manager_Db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuctionModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AuctionModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuctionModel>>> GetAuctions()
        {
            return await _context.Auctions.ToListAsync();
        }

        // GET: api/AuctionModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionModel>> GetAuctionModel(int id)
        {
            var auctionModel = await _context.Auctions.FindAsync(id);

            if (auctionModel == null)
            {
                return NotFound();
            }

            return auctionModel;
        }

        // PUT: api/AuctionModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuctionModel(int id, AuctionModel auctionModel)
        {
            if (id != auctionModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(auctionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AuctionModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuctionModel>> PostAuctionModel(AuctionModel auctionModel)
        {
            _context.Auctions.Add(auctionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuctionModel", new { id = auctionModel.Id }, auctionModel);
        }

        // DELETE: api/AuctionModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuctionModel(int id)
        {
            var auctionModel = await _context.Auctions.FindAsync(id);
            if (auctionModel == null)
            {
                return NotFound();
            }

            _context.Auctions.Remove(auctionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuctionModelExists(int id)
        {
            return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
