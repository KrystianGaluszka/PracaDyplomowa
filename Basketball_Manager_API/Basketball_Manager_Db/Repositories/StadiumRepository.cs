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
    public class StadiumRepository : IStadiumRepository
    {
        private readonly ApplicationDbContext _context;
        public StadiumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StadiumViewModel>> GetAllStadiums()
        {
            var stadiums = await _context.Stadiums.ToListAsync();
            var mapper = new Mapper(MapperConfig());

            var stadiumsModel = mapper.Map<List<StadiumModel>, List<StadiumViewModel>>(stadiums);

            return stadiumsModel;
        }

        public async Task<StadiumViewModel> GetStadium(int id)
        {
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(x => x.Id == id);
            var mapper = new Mapper(MapperConfig());

            var stadiumModel = mapper.Map<StadiumModel, StadiumViewModel>(stadium);

            return stadiumModel;
        }
    }
}
