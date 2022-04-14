using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class UserPlayerProfile : Profile
    {
        public UserPlayerProfile()
        {
            CreateMap<UsersPlayerModel, UsersPlayerViewModel>();
            CreateMap<UsersPlayerPointsModel, UsersPlayerPointsViewModel>();
            CreateMap<UsersPlayerStateModel, UsersPlayerStateViewModel>();
            AllowNullCollections = true;
        }
    }
}
