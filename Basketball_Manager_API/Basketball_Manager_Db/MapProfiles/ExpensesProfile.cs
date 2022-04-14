using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Db.MapProfiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<ExpensesModel, ExpensesViewModel>();
            CreateMap<ExpensesViewModel, ExpensesModel>();
            AllowNullCollections = true;
        }
    }
}
