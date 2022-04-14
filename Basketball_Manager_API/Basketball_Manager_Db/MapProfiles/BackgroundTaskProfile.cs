using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Db.MapProfiles
{
    public class BackgroundTaskProfile : Profile
    {
        public BackgroundTaskProfile()
        {
            CreateMap<BackgroundTaskModel, BackgroundTaskViewModel>();
            CreateMap<BackgroundTaskViewModel, BackgroundTaskModel>();
            AllowNullCollections = true;
        }
    }
}
