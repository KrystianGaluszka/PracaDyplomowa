using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Db.MapProfiles
{
    public class SponsorsProfile : Profile
    {
        public SponsorsProfile()
        {
            CreateMap<SponsorsModel, SponsorsViewModel>();
            AllowNullCollections = true;
        }
    }
}
