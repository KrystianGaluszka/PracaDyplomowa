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

        public async Task<string> UpgradeStadium(UpgradeStadiumPutModel upgradeStadiumPutModel)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == upgradeStadiumPutModel.UserId);
            var stadium = _context.Stadiums.FirstOrDefault(x => x.Id == upgradeStadiumPutModel.StadiumId);
            if (user != null && stadium != null)
            {
                user.Money -= stadium.Price;
                var expense = new ExpensesModel
                {
                    ItemName = $"Stadium upgrade to level {stadium.Level + 1}",
                    Count = 1,
                    IconPath = "https://localhost:44326/images/stadium-icon.png",
                    TransactionDate = DateTime.Now,
                    UserId = user.Id,
                    Value = stadium.Price.ToString(),
                };

                switch (stadium.Level)
                {
                    case 1:
                        stadium.Level = 2;
                        stadium.Price = 15000;
                        stadium.SeatsCapacity = 250;
                        break;
                    case 2:
                        stadium.Level = 3;
                        stadium.IncomePerViewer = 25;
                        stadium.Price = 25000;
                        stadium.SeatsCapacity = 300;
                        break;
                    case 3:
                        stadium.Level = 4;
                        stadium.Price = 30000;
                        stadium.SeatsCapacity = 500;
                        break;
                    case 4:
                        stadium.Level = 5;
                        stadium.IncomePerViewer = 50;
                        stadium.Price = 0;
                        break;
                }

                _context.Expenses.Add(expense);

                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }

        public async Task<string> ChangeStadiumName(StadiumPutModel stadiumPutModel)
        {
            var stadium = _context.Stadiums.FirstOrDefault(x => x.Id == stadiumPutModel.StadiumId);
            if (stadium != null)
            {
                stadium.Name = stadiumPutModel.StadiumName;
                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }
    }
}
