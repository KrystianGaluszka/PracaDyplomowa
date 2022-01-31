using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.MapProfiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerModel, PlayerViewModel>();
            CreateMap<UsersPlayerViewModel, UsersPlayerModel>();
            CreateMap<PlayerViewModel, UsersPlayerViewModel>();
            AllowNullCollections = true;
        }
    }
}
