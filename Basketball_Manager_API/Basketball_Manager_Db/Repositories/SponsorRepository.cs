using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PutModels;
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

        public async Task<IEnumerable<UsersSponsorViewModel>> GetAllUserSponsors()
        {
            var sponsors = await _context.UsersSponsors.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var sponsorsModel = mapper.Map<List<UsersSponsorModel>, List<UsersSponsorViewModel>>(sponsors);

            return sponsorsModel;
        }

        public async Task<UsersSponsorViewModel> GetUserSponsor(int id)
        {
            var sponsor = await _context.UsersSponsors.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var sponsorModel = mapper.Map<UsersSponsorModel, UsersSponsorViewModel>(sponsor);

            return sponsorModel;
        }

        public async Task<IEnumerable<SponsorsViewModel>> GetAllSponsors()
        {
            var sponsors = await _context.Sponsors.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var sponsorsModel = mapper.Map<List<SponsorsModel>, List<SponsorsViewModel>>(sponsors);

            return sponsorsModel;
        }

        public async Task<SponsorsViewModel> GetSponsor(int id)
        {
            var sponsor = await _context.Sponsors.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var sponsorModel = mapper.Map<SponsorsModel, SponsorsViewModel>(sponsor);

            return sponsorModel;
        }

        public async Task<string> ChangeSponsor(ChangeSponsorPutModel changeSponsorPutModel)
        {
            var user = _context.Users.FirstOrDefault(x=> x.Id == changeSponsorPutModel.UserId);
            if (user != null)
            {
                var userSponsor = _context.UsersSponsors.FirstOrDefault(x => x.UserId == user.Id);
                if (userSponsor != null)
                {
                    var sponsor = _context.Sponsors.FirstOrDefault(x=> x.Id == changeSponsorPutModel.SponsorId);
                    userSponsor.SponsorId = changeSponsorPutModel.SponsorId;
                    userSponsor.MatchPrizeCount = 0;
                    userSponsor.MatchPrizeTotality = 0;
                    userSponsor.TitlePrizeCount = 0;
                    userSponsor.TitlePrizeTotality = 0;
                    userSponsor.WinPrizeCount = 0;
                    userSponsor.WinPrizeTotality = 0;

                    await _context.SaveChangesAsync();

                    return "success";
                }
                else return "error";
            }
            else return "error";
        }
    }
}
