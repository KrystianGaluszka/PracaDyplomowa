using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Db.MapProfiles
{
    public class RankRequirementProfile: Profile
    {
        public RankRequirementProfile()
        {
            CreateMap<RankRequirementModel, RankRequirementViewModel>();
            CreateMap<RankRequirementViewModel, RankRequirementModel>();
            AllowNullCollections = true;
        }
    }
}
