using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly ApplicationDbContext _context;
        public SponsorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SponsorViewModel>> GetAllSponsors()
        {
            var sponsors = await _context.Sponsors.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var sponsorsModel = mapper.Map<List<SponsorModel>, List<SponsorViewModel>>(sponsors);

            return sponsorsModel;
        }

        public async Task<SponsorViewModel> GetSponsor(int id)
        {
            var sponsor = await _context.Sponsors.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var sponsorModel = mapper.Map<SponsorModel, SponsorViewModel>(sponsor);

            return sponsorModel;
        }
    }
}
